namespace Metrics_Track.Models
{
    using Metrics_Track.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    public class ProcessViewModel
    {
        public int ID_Process { get; set; }
        public List<ProcessDataModel> ProcessList => new List<ProcessDataModel>();

        public IEnumerable<SelectListItem> ProcessEnum
        {
            get
            {
                return new SelectList(ProcessList, "ID", "ProcessName");
            }
        }
    }
}
