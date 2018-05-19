namespace Metrics_Track.Data.Models
{
    public class trel_ProcessStatus
    {
        public int IdSp { get; set; }
        public int? IdProcess { get; set; }
        public int? IdStatus { get; set; }

        public tbl_Process IdProcessNavigation { get; set; }
        public tbl_Status IdStatusNavigation { get; set; }
    }
}
