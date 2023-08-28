using FluentValidation.Results;

namespace HRPlus.Application.Expections
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string massage) : base(massage)
        {

        }
        
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            VaildationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                VaildationErrors.Add(error.ErrorMessage);
            }
        }

        public List<string> VaildationErrors { get; set; }
    }
}

