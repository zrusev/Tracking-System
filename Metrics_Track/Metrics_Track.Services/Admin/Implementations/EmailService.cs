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

        public async Task<string> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                //send directly to admin
                if (email.Equals(string.Empty))
                {
                    email = this.ec.AdminEmailAddress;
                }

                emailMessage.From.Add(new MailboxAddress(this.ec.FromName, this.ec.FromAddress));
                emailMessage.To.Add(new MailboxAddress(string.Empty, email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };

                using (var client = new SmtpClient())
                {
                    client.LocalDomain = this.ec.LocalDomain;

                    await client.ConnectAsync(this.ec.MailServerAddress, Convert.ToInt32(this.ec.MailServerPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(this.ec.UserId, this.ec.UserPassword));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }

                return "Confirmation e-mail sent to agent successfully.";
            }
            catch (Exception ex)
            {
                return "Something went wrong. " + ex.Message;
            }
        }
    }
}
