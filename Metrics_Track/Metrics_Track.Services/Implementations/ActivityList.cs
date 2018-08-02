namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Activity;
    using System.Collections.Generic;
    using System.Linq;

    public class ActivityList : IActivityList
    {
        private readonly TrackerDbContext db;

        public ActivityList(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ActivityModel> All()
            => this.db
                .TblActivity
                .OrderBy(a => a.Activity)
                .ProjectTo<ActivityModel>()
                .ToList();

        public ActivityModel ById(int id)
            => this.db
                .TblActivity
                .Where(i => i.IdActivity == id)
                .ProjectTo<ActivityModel>()
                .FirstOrDefault();

        public int[] Ids(int id)
             => this.db
                .TrelProcessActivity
                .Where(i => i.IdProcess == id)
                .Select(a => (int)a.IdActivity)
                .ToArray();

        public int UpdateActivity(ActivityModel model)
        {
            var activity = this.db
                .TblActivity
                .Where(i => i.IdActivity == model.IdActivity)
                .FirstOrDefault();

            activity.Activity = model.Activity;

            this.db.TblActivity.Update(activity);
            this.db.SaveChanges();

            return activity.IdActivity;
        }

        public int AddActivity(ActivityModel model)
        {
            var activity = new tbl_Activity()
            {
                Activity = model.Activity
            };

            this.db.TblActivity.Add(activity);
            this.db.SaveChanges();

            return activity.IdActivity;
        }

        public void RemoveActivity(int id)
        {
            var activity = this.db
                .TblActivity
                .Where(i => i.IdActivity == id)
                .FirstOrDefault();

            this.db.TblActivity.Remove(activity);
            this.db.SaveChanges();
        }

        public void UpdateIds(int idProcess, int[] ids)
        {
            var currentIds = this.db
                .TrelProcessActivity
                .Where(i => i.IdProcess == idProcess)
                .ToList();

            if (currentIds.Count > 0)
            {
                this.db.TrelProcessActivity.RemoveRange(currentIds);
            }

            var newMap = ids.SelectMany(p => new int[] { idProcess },
                                       (p, c) => new trel_ProcessActivity { IdProcess = c, IdActivity = p });

            this.db.TrelProcessActivity.AddRange(newMap);
            this.db.SaveChanges();
        }
    }
}
