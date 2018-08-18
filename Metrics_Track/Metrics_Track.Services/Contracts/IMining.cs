namespace Metrics_Track.Services.Contracts
{
    using Models.Mining;
    using Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMining
    {
        IEnumerable<MiningModel> ById(int id);

        void AddUserActivity(UserActivityModel model);

        Task<UserDetailsModel> UserDetailsAsync();

        IEnumerable<MiningModel> MiningByUserId(string id);
    }
}
