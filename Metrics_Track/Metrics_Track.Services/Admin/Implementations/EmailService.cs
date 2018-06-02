namespace Metrics_Track.Services.Admin.Models
{
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using Metrics_Track.Services.Admin.Contracts;
    using Microsoft.Extensions.Options;
    using MimeKit;
    using MimeKit.Text;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class EmailService : IEmailService
    {
        private readonly EmailConfigModel ec;

        public EmailService(IOptions<EmailConfigModel> emailConfig)
        {
            this.ec = emailConfig.Value;
        }

        public async Task<string> SendEmailAsync(String email, String subject, String message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                //send directly to admin
                if (email.Equals(string.Empty))
                {
                    email = ec.AdminEmailAddress;
                }

                emailMessage.From.Add(new MailboxAddress(ec.FromName, ec.FromAddress));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };

                using (var client = new SmtpClient())
                {
                    client.LocalDomain = ec.LocalDomain;

                    await client.ConnectAsync(ec.MailServerAddress, Convert.ToInt32(ec.MailServerPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(ec.UserId, ec.UserPassword));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }

                return "Confirmation e-mail sent to agent successfully.";
            }
            catch (Exception ex)
            {
                return "Something went wrong. " +  ex.Message;
            }
        }
    }
}
