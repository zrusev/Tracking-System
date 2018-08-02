namespace Metrics_Track.Areas.Admin.Models.ProcessActivity
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class ProcessActivityMappingViewModel
    {
        public int IdSelectedProcess { get; set; }

        public string SelectedProcess { get; set; }

        public int[] IdActivities { get; set; }

        public IEnumerable<SelectListItem> Activities { get; set; }
    }
}
