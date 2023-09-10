using Microsoft.AspNetCore.Mvc;

namespace HRPlus.Api.Models
{
    public class CustomenExpectionProblemsDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
