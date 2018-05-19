namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_TowerCategory
    {
        public tbl_TowerCategory()
        {
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelProcessTowerCategory = new HashSet<trel_ProcessTowerCategory>();
        }

        public int IdTowerCategory { get; set; }
        public string TowerCategory { get; set; }

        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_ProcessTowerCategory> TrelProcessTowerCategory { get; set; }
    }
}
