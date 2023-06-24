using System.Threading.Tasks;

namespace OnlineShopWebApp.Helpers
{
    public interface IMailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
