namespace Metrics_Track.Services.Contracts
{
    using Models.Activity;
    using System.Collections.Generic;
    public interface IActivity
    {
        IEnumerable<ActivityModel> All();

        ActivityModel ById(int id);

        int UpdateActivity(ActivityModel model);

        int AddActivity(ActivityModel model);

        void RemoveActivity(int id);
    }
}
