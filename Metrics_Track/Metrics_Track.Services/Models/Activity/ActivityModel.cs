namespace Metrics_Track.Services.Models.Activity
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;

    public class ActivityModel : IMapFrom<tbl_Activity>
    {
        public int IdActivity { get; set; }

        public string Activity { get; set; }
    }
}
