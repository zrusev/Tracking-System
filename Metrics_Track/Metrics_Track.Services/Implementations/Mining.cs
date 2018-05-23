namespace Metrics_Track.Services.Implementations
{
    using Contracts;
    using Metrics_Track.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Mining;
    using Models.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class Mining : IMining
    {
        private readonly TrackerDbContext db;

        public Mining(TrackerDbContext db)
        {
            this.db = db;
        }

        public void AddUserActivity(int id, string type, DateTime stamp, string commment, short sandbox)
        {
            var currentActivity = new tbl_UserActivity
            {
                IdLogin = id,
                Type = type,
                ChangeStamp = stamp,
                Comment = commment,
                Sandbox = sandbox
            };
            
            this.db.TblUserActivity.Add(currentActivity);
            this.db.SaveChanges();
        }

        public IEnumerable<MiningModel> ById(int id)
        {
            var minings = this.db.TblMining
                        .Where(t => t.TrelUserMining.Any(i => i.IdLogin == id))
                        .Select(m => new MiningModel
                        {
                            IdMining = m.IdMining,
                            State = m.State
                        })
                        .ToList();

            return minings;
        }

        public async Task<UserDetailsModel> UserDetailsAsync()
            => await this.db.Users
                    .Select(u => new UserDetailsModel
                    {
                        IdLogin = u.IdLogin,
                        Sandbox = u.Sandbox
                    })
                    .FirstOrDefaultAsync();         
    }
}
