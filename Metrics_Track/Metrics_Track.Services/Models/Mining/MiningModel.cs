namespace Metrics_Track.Services.Models.Mining
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;

    public class MiningModel : IMapFrom<tbl_Mining>
    {
        public int IdMining { get; set; }

        public string State { get; set; }
    }
}
