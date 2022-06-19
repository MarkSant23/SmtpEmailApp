namespace SmtpEmailApp.EmailService
{
    public interface IEmailService
    {
        void SentMail(Email request);
    }
}
