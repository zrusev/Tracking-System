namespace Metrics_Track.Areas.Admin.Models.Processes
{
    using Metrics_Track.Services.Models.Process;
    using System.Collections.Generic;
    public class ProcessListViewModel
    {
        public IEnumerable<ProcessListModel> ProcessList { get; set; } = new List<ProcessListModel>();
    }
}
