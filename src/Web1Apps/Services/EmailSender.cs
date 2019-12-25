using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Web1Apps.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly AuthMessageSenderOptions _options;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            string apiKey = _options.SendGridKey;
            string fromEmail = _options.SendGridFromEmail;
            string user = _options.SendGridUser;

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, user),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            var client = new SendGridClient(apiKey);
            return client.SendEmailAsync(msg);
        }
    }
}
