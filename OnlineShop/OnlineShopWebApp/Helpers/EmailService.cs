using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Helpers
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kozyreva_online_shop@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("Онлайн Магазин игрушек", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                // показать как настраивать доступ через почту и получить пароль
                await client.ConnectAsync("smtp.mail.ru", 587);
                await client.AuthenticateAsync("kozyreva_online_shop@mail.ru", "hjuzZFcUbzfXAnc9BDdt");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

            // нужно ли показывать отправку через google почту и Яндекс? или майл.ру достаточно?
        }
    }
}
