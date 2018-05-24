namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Mining;
    using Models.User;
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

        public void AddUserActivity(UserActivityModel model)
        {
            this.db
                .TblUserActivity
                .Add(new tbl_UserActivity {
                    IdLogin = model.IdLogin,
                    Type = model.Type,
                    ChangeStamp = model.ChangeStamp,
                    Comment = model.Comment,
                    Sandbox = model.Sandbox
                });
            this.db.SaveChanges();
        }

        public IEnumerable<MiningModel> ById(int id)
             => this.db
                    .TblMining
                    .Where(t => t.TrelUserMining.Any(i => i.IdLogin == id))
                    .ProjectTo<MiningModel>()
                    .ToList();

        public async Task<UserDetailsModel> UserDetailsAsync()
            => await this.db
                    .Users
                    .ProjectTo<UserDetailsModel>()
                    .FirstOrDefaultAsync();         
    }
}
