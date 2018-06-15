namespace Metrics_Track.Areas.Admin.Models.Divisions
{
    using Metrics_Track.Services.Models.Division;
    using System.Collections.Generic;
    public class DivisionListViewModel
    {
        public IEnumerable<DivisionModel> DivisionList { get; set; } = new List<DivisionModel>();
    }
}
