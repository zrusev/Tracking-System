namespace Metrics_Track.Areas.Admin.Models.ProcessLob
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class ProcessLobViewModel
    {
        public int[] IdProcesses { get; set; }

        public IEnumerable<SelectListItem> ProcessList { get; set; } = new List<SelectListItem>();
    }
}
