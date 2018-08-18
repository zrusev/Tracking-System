namespace Metrics_Track.Services.Admin.Contracts
{
    using System.Threading.Tasks;

    public interface IEmailService
    {
        Task<string> SendEmailAsync(string email, string subject, string message);
    }
}
