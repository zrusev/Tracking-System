namespace Metrics_Track.Areas.Admin.Models.ProcessDivision
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class ProcessDivisionMappingViewModel
    {
        public int IdSelectedProcess { get; set; }

        public string SelectedProcess { get; set; }

        public int[] IdDivisions { get; set; }

        public IEnumerable<SelectListItem> Divisions { get; set; }
    }
}
