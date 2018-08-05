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
                    .OrderBy(l => l.Email)                
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

        public void RemoveAgentToCountryTrel(string agentId)
        {
            var trelList =  this.db
                 .TrelAgentCountry
                 .Where(i => i.IdAgent == agentId)
                 .ToList();

            foreach (var trel in trelList)
            {
                this.db.TrelAgentCountry.Remove(trel);
            }

            this.db.SaveChanges();
        }

        public void RemoveTeamLeaderById(string agengId)
        {
            var user = this.db
                .Users
                .Where(i => i.Id == agengId)
                .FirstOrDefault();

            user.IdTeamLead = null;

            this.db.Users.Update(user);
            this.db.SaveChanges();
        }

        public void AddToManagersList(User user)
        {
            var teamLead = new tbl_TeamLead
            {
                TeamLead = user.FirstName + " " + user.LastName,
                User = user
            };

            this.db.TblTeamLead.Add(teamLead);
            this.db.SaveChanges();
        }

        public void RemoveFromManagersList(User user)
        {
            var teamLead = this.db
                .TblTeamLead
                .Where(u => u.User.IdTeamLead == user.IdTeamLead)
                .SingleOrDefault();

            this.db.TblTeamLead.Remove(teamLead);
            this.db.SaveChanges();
        }
    }
}
