namespace Metrics_Track.Services.Models.Status
{
    using Common.Mapping;
    using Data.Models;

    public class StatusModel : IMapFrom<tbl_Status>
    {
        public int IdStatus { get; set; }

        public string Status { get; set; }
    }
}
