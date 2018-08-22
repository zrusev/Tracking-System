namespace Metrics_Track.Services.Admin.Contracts
{
    using Data.Models;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUser
    {
        Task<IEnumerable<AdminUserListingModel>> AllAsync();

        Task<AdminUserListingModel> UserByIdAsync(string userId);

        void RemoveAgentToCountryTrel(string agentId);

        void RemoveTeamLeaderById(string agengId);

        void AddToManagersList(User user);

        void RemoveFromManagersList(User user);
    }
}
