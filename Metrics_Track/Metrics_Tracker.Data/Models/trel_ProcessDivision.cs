namespace Metrics_Track.Data.Models
{
    public class trel_ProcessDivision
    {
        public int IdPd { get; set; }

        public int? IdProcess { get; set; }

        public int? IdDivision { get; set; }

        public tbl_Division IdDivisionNavigation { get; set; }

        public tbl_Process IdProcessNavigation { get; set; }
    }
}
