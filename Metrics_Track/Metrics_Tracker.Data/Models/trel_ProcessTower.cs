namespace Metrics_Track.Data.Models
{
    public class trel_ProcessTower
    {
        public int IdPt { get; set; }

        public int? IdProcess { get; set; }

        public int? IdTower { get; set; }

        public tbl_Process IdProcessNavigation { get; set; }

        public tbl_Tower IdTowerNavigation { get; set; }
    }
}
