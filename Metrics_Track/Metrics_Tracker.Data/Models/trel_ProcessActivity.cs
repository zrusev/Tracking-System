namespace Metrics_Track.Data.Models
{
    public class trel_ProcessActivity
    {
        public int IdPa { get; set; }

        public int? IdProcess { get; set; }

        public int? IdActivity { get; set; }

        public tbl_Activity IdActivityNavigation { get; set; }

        public tbl_Process IdProcessNavigation { get; set; }
    }
}
