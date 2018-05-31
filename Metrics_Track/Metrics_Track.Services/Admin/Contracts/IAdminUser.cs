namespace Metrics_Track.Services.Admin.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAdminUser
    {
        Task<IEnumerable<AdminUserListingModel>> AllAsync();
    }
}
