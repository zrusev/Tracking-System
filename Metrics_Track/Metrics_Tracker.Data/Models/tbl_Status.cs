namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Status
    {
        public tbl_Status()
        {
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelProcessStatus = new HashSet<trel_ProcessStatus>();
        }

        public int IdStatus { get; set; }
        public string Status { get; set; }
        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_ProcessStatus> TrelProcessStatus { get; set; }
    }
}
