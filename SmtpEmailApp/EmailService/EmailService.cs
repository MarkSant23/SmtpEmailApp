using MailKit.Net.Smtp;
using MimeKit;

namespace SmtpEmailApp.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SentMail(Email request)
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            mail.To.Add(MailboxAddress.Parse(request.To));

            mail.Subject = request.Subject;
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            //domain (gmail.com...etc), port
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(mail);
            smtp.Disconnect(true);

            
        }
    }
}
