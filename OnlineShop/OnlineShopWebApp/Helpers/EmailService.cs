using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnlineShopWebApp.Configuration;

namespace OnlineShopWebApp.Helpers
{
    public class EmailService: IMailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            emailMessage.To.Add(new MailboxAddress(_mailSettings.DisplayName, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                // показать как настраивать доступ через почту и получить пароль
                await client.ConnectAsync(_mailSettings.Host, _mailSettings.Port);
                await client.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
