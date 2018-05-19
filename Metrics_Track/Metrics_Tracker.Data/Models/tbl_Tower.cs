namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Tower
    {
        public tbl_Tower()
        {
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelProcessTower = new HashSet<trel_ProcessTower>();
        }

        public int IdTower { get; set; }
        public string Tower { get; set; }

        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_ProcessTower> TrelProcessTower { get; set; }
    }
}
