namespace Metrics_Track.Services.Implementations
{
    using Metrics_Track.Data.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Mining : IMining
    {
        private readonly TrackerDbContext db;

        public Mining(TrackerDbContext db)
        {
            this.db = db;
        }

        public void AddUserActivity(int id, string type, DateTime stamp, string commment, short sandbox, string version)
        {
            var currentActivity = new tbl_UserActivity
            {
                IdLogin = id,
                Type = type,
                ChangeStamp = stamp,
                Comment = commment,
                Sandbox = sandbox,
                MetricsTrackVer = version
            };
            
            this.db.TblUserActivity.Add(currentActivity);
            this.db.SaveChanges();
        }

        public IEnumerable<MiningDataModel> ById(int id)
        {
            var minings = this.db.TblMining
                        .Where(t => t.TrelUserMining.Any(i => i.IdLogin == id))
                        .Select(m => new MiningDataModel
                        {
                            IdMining = m.IdMining,
                            State = m.State
                        })
                        .ToList();

            return minings;
        }
    }
}
