using HMS.Interface;
using System.Net.Mail;
using System.Net;

namespace HMS.Service
{
    public class EmailService : IEmailService
    {
        private static readonly string smtpHost = "smtp.gmail.com";
        private static readonly int smtpPort = 587;
        private static readonly string smtpUsername = "irakliberdzena314@gmail.com";
        private static readonly string smtpPassword = "coca mmba ywsy lvyz";

        public async Task SendEmailAsync(string email, string subject, string htmlBody)
        {
            using (var client = new SmtpClient(smtpHost, smtpPort))
            {
                client.Host = smtpHost;
                client.Port = smtpPort;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(smtpUsername, "HMS");
                    message.To.Add(new MailAddress(email));
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = htmlBody;

                    await client.SendMailAsync(message);
                }
            }
        }
    }
}
