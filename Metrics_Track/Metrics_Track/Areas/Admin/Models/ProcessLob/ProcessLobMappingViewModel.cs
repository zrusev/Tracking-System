namespace Metrics_Track.Areas.Admin.Models.ProcessLob
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class ProcessLobMappingViewModel
    {
        public int IdSelectedProcess { get; set; }

        public string SelectedProcess { get; set; }

        public int[] IdLobs { get; set; }

        public IEnumerable<SelectListItem> Lobs { get; set; }
    }
}
