using FluentValidation.Results;

namespace HRPlus.Application.Expections
{
    public class BedRequestExepection : Exception
    {
        public BedRequestExepection(string massage) : base(massage)
        {

        }
        
        public BedRequestExepection(string message, ValidationResult validationResult) : base(message)
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

