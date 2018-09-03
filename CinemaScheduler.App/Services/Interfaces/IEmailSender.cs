using System.Threading.Tasks;

namespace CinemaScheduler.App.Services
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(string email, string subject, string body);

    }
}
