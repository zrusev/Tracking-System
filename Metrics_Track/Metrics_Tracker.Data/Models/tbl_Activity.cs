namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Activity
    {
        public tbl_Activity()
        {
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelProcessActivity = new HashSet<trel_ProcessActivity>();
        }

        public int IdActivity { get; set; }
        public string Activity { get; set; }

        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_ProcessActivity> TrelProcessActivity { get; set; }
    }
}
