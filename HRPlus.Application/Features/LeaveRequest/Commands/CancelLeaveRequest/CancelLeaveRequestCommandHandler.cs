using HRPlus.Application.Contracts.Email;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using HRPlus.Application.Models.Email;
using MediatR;

namespace HRPlus.Application.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class CancelLeaveRequestCommandHandler : IRequest<CancelLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;

        public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
        }
        
        public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            
            var leaveRequestObject = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if(leaveRequestObject is null)
                throw new NotFoundException(nameof(leaveRequestObject), request.Id);

            leaveRequestObject.Canceled = true;

            // Re-evalutae the employee's allocations for the leave Type

            // send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {leaveRequestObject.StartDate:D} to {leaveRequestObject.EndDate:D} has been cancelled successfully.",
                    Subject = "Leave Request Cancelled"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception)
            {
                // log error
            }

            return Unit.Value;
        }
    }
}
