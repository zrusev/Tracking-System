namespace Metrics_Track.Services.Models.Mining
{
    using Common.Mapping;
    using Data.Models;

    public class MiningModel : IMapFrom<tbl_Mining>
    {
        public int IdMining { get; set; }

        public string State { get; set; }
    }
}
