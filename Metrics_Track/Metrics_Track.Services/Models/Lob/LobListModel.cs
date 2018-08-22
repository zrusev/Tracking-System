namespace Metrics_Track.Services.Models.Lob
{
    using Common.Mapping;
    using Data.Models;

    public class LobListModel : IMapFrom<tbl_Lob>
    {
        public int IdLob { get; set; }

        public string Lob { get; set; }

        public string MmcpLob { get; set; }

        public string MmcpSegment { get; set; }

        public string ProductLine1 { get; set; }

        public string ProductLine2 { get; set; }

        public string ProductLine3 { get; set; }

        public int? SpphIdProduct { get; set; }
    }
}
