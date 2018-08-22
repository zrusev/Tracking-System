namespace Metrics_Track.Services.Models.Activity
{
    using Common.Mapping;
    using Data.Models;

    public class ActivityModel : IMapFrom<tbl_Activity>
    {
        public int IdActivity { get; set; }

        public string Activity { get; set; }
    }
}
