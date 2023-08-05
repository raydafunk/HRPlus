using HRPlus.Application.Models.Email;

namespace HRPlus.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
