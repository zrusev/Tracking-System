namespace Metrics_Track.Services.Implementations
{
    using Contracts;
    using System.Threading.Tasks;

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
