using System.Net;
using System.Threading.Tasks;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace CinemaScheduler.App.Services
{
    public class EmailSender : IEmailSender
    {
        private const string API_KEY_NAME = "CinemaScheduler";
        private const string API_KEY_SECRET = "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";

        public async Task<bool> SendEmail(string email, string subject, string body)
        {
            var client = new SendGridClient(API_KEY_SECRET);
            var from = new EmailAddress("cinema@scheduler.com", "Cinema");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var result = await client.SendEmailAsync(msg);

            return result.StatusCode <= HttpStatusCode.Accepted;
        }

        public async Task<bool> Test()
        {
            var client = new SendGridClient(API_KEY_SECRET);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var result = await client.SendEmailAsync(msg);

            return result.StatusCode == HttpStatusCode.Accepted;
        }
    }
}