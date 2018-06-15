namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Activity;
    using System.Collections.Generic;
    using System.Linq;

    public class Activity : IActivity
    {
        private readonly TrackerDbContext db;

        public Activity(TrackerDbContext db)
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
    }
}
