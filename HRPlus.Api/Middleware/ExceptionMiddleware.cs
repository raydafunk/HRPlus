using HRPlus.Api.Models;
using HRPlus.Application.Expections;
using System.Net;

namespace HRPlus.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegateAction;

        public ExceptionMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegateAction = nextRequestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _nextRequestDelegateAction(httpcontext);
            }
            catch (Exception ex)
            {

                await HnadleExceptionAsync(httpcontext, ex);
            }
        }

        private async Task HnadleExceptionAsync(HttpContext httpcontext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomenExpectionProblemsDetails problemsDetails = new();

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problemsDetails = new CustomenExpectionProblemsDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        Errors = badRequestException.ValidationErrors
                    };
                    break;
                    case NotFoundException NotFoundException:
                     statusCode = HttpStatusCode.NotFound;
                    problemsDetails = new CustomenExpectionProblemsDetails
                    {
                        Title = NotFoundException.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                        Detail = NotFoundException.InnerException?.Message,
                    };  
                    break;
                default:
                    problemsDetails = new CustomenExpectionProblemsDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Type = nameof(HttpStatusCode.InternalServerError),
                        Detail = ex.StackTrace,
                    };
                    break;
            }
            httpcontext.Response.StatusCode = (int)statusCode;
            await httpcontext.Response.WriteAsJsonAsync(problemsDetails);
        }
    }
}
