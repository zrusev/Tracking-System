namespace Metrics_Track.Areas.Admin.Models.ProcessStatus
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class ProcessStatusMappingViewModel
    {
        public int IdSelectedProcess { get; set; }

        public string SelectedProcess { get; set; }

        public int[] IdStatuses { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}
