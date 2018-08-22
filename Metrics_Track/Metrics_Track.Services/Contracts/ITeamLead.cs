namespace Metrics_Track.Services.Contracts
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeamLead
    {
        Task<IEnumerable<SelectListItem>> AllAsync();

        Task<TeamLeadListingModel> FindTeamLeadAsync(int id);
    }
}
