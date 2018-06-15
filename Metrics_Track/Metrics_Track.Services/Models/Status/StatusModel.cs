namespace Metrics_Track.Services.Models.Status
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;
    public class StatusModel : IMapFrom<tbl_Status>
    {
        public int IdStatus { get; set; }

        public string Status { get; set; }
    }
}
