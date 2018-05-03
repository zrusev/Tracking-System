namespace Metrics_Track.Data.Models
{
    public class trel_UserMining
    {
        public int IdUm { get; set; }
        public int? IdLogin { get; set; }
        public int? IdMining { get; set; }
        public tbl_Login IdLoginNavigation { get; set; }
        public tbl_Mining IdMiningNavigation { get; set; }
    }
}
