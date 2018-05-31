namespace Metrics_Track.Services.Admin.Implementations
{
    using Contracts;
    using Metrics_Track.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminUser : IAdminUser
    {
        private const string AdministratorRole = "Administrator";

        private readonly TrackerDbContext db;

        public AdminUser(TrackerDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingModel>> AllAsync()
            => await this.db
                .Users
                .Select(u => new AdminUserListingModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IdLogin = u.IdLogin,
                    IdTeamLead = u.IdTeamLead,
                    TeamLead = u.TeamLead.TeamLead,
                    Sandbox = u.Sandbox,
                    Countries = u.Countries.Select(c => c.Country).ToList()                    
                })
                .Where(u => u.Username != AdministratorRole)
                .OrderBy(n => n.IdTeamLead != null)
                .ThenByDescending(l => l.IdLogin)
                .ToListAsync();

        public async Task<AdminUserListingModel> UserByIdAsync(string userId)
            => await this.db
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new AdminUserListingModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IdLogin = u.IdLogin,
                    IdTeamLead = u.IdTeamLead,
                    TeamLead = u.TeamLead.TeamLead,
                    Sandbox = u.Sandbox,
                    Countries = u.Countries.Select(c => c.Country).ToList()
                })
                .FirstOrDefaultAsync();
    }
}
