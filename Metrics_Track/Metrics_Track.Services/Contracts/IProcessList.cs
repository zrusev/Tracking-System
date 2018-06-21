namespace Metrics_Track.Services.Contracts
{
    using Models.Process;
    using System.Collections.Generic;

    public interface IProcessList
    {
        IEnumerable<ProcessListModel> All();

        ProcessListModel ById(int id);

        int UpdateProcess(ProcessListModel model);

        int AddProcess(ProcessListModel model);

        void RemoveProcess(int id);

        int[] Ids(int id);

        void UpdateIds(int idCountry, int[] ids);
    }
}
