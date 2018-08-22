namespace Metrics_Track.Web.Areas.Admin.Models.Processes
{
    using Services.Models.Process;
    using System.Collections.Generic;

    public class ProcessListViewModel
    {
        public IEnumerable<ProcessListModel> ProcessList { get; set; } = new List<ProcessListModel>();
    }
}
