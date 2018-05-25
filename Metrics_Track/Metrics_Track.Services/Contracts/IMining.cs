namespace Metrics_Track.Services.Contracts
{
    using Metrics_Track.Data.Models;
    using Models.Mining;
    using Models.User;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IMining
    {
        IEnumerable<MiningModel> ById(int id);

        void AddUserActivity(UserActivityModel model);

        Task<UserDetailsModel> UserDetailsAsync();

        IQueryable<IEnumerable<MiningModel>> MiningByUserId(string id);
    }
}
