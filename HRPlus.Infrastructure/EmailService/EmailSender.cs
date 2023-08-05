using HRPlus.Application.Contracts.Email;
using HRPlus.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HRPlus.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings  _emailSettigns { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettigns = emailSettings.Value;
        }
        /// <summary>
        ///   the setting up of sending the email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettigns.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettigns.FromAdress,
                Name  = _emailSettigns.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body,email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}
