namespace Metrics_Track.Services.Contracts
{
    using Models.Status;
    using System.Collections.Generic;

    public interface IStatusList
    {
        IEnumerable<StatusModel> All();

        StatusModel ById(int id);

        int UpdateStatus(StatusModel model);

        int AddStatus(StatusModel model);

        void RemoveStatus(int id);

        int[] Ids(int id);

        void UpdateIds(int idProcess, int[] ids);
    }
}
