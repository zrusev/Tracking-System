namespace Metrics_Track.Services.Contracts
{
    using Metrics_Track.Services.Models.User;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeamLead
    {
        Task<IEnumerable<SelectListItem>> AllAsync();

        Task<TeamLeadListingModel> FindTeamLeadAsync(int id);
    }
}
