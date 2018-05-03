namespace Metrics_Track.Data.Models
{
    public class trel_ProcessLob
    {
        public int IdPl { get; set; }
        public int? IdProcess { get; set; }
        public int? IdLob { get; set; }
        public tbl_Lob IdLobNavigation { get; set; }
        public tbl_Process IdProcessNavigation { get; set; }
    }
}
