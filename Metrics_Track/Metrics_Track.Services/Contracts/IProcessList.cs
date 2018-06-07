namespace Metrics_Track.Services.Contracts
{
    using Models.Process;
    using System.Collections.Generic;

    public interface IProcessList
    {
        IEnumerable<ProcessListModel> All();
    }
}
