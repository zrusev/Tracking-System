namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Metrics_Track.Services.Models.User;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeamLead : ITeamLead
    {
        private readonly TrackerDbContext db;

        public TeamLead(TrackerDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<SelectListItem>> AllAsync()
            => await this.db
                    .TblTeamLead
                    .ProjectTo<TeamLeadListingModel>()
                    .Select(l => new SelectListItem
                    {
                        Text = l.TeamLead,
                        Value = l.IdTeamLead.ToString()
                    })
                    .ToListAsync();

        public async Task<TeamLeadListingModel> FindTeamLeadAsync(int id)
            => await this.db
                    .TblTeamLead
                    .Where(t => t.IdTeamLead == id)
                    .ProjectTo<TeamLeadListingModel>()
                    .FirstOrDefaultAsync();
    }
}
