namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Lob
    {
        public tbl_Lob()
        {
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelProcessLob = new HashSet<trel_ProcessLob>();
        }

        public int IdLob { get; set; }
        public string Lob { get; set; }
        public string MmcpLob { get; set; }
        public string MmcpSegment { get; set; }
        public string ProductLine1 { get; set; }
        public string ProductLine2 { get; set; }
        public string ProductLine3 { get; set; }
        public int? SpphIdProduct { get; set; }
        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_ProcessLob> TrelProcessLob { get; set; }
    }
}
