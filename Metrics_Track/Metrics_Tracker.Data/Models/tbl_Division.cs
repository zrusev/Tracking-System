namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Division
    {
        public tbl_Division()
        {
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelProcessDivision = new HashSet<trel_ProcessDivision>();
        }

        public int IdDivision { get; set; }
        public string Division { get; set; }

        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_ProcessDivision> TrelProcessDivision { get; set; }
    }
}
