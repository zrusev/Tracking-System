namespace Metrics_Track.Services.Contracts
{
    using Models.Activity;
    using System.Collections.Generic;
    public interface IActivityList
    {
        IEnumerable<ActivityModel> All();

        ActivityModel ById(int id);

        int UpdateActivity(ActivityModel model);

        int AddActivity(ActivityModel model);

        void RemoveActivity(int id);

        int[] Ids(int id);

        void UpdateIds(int idProcess, int[] ids);
    }
}
