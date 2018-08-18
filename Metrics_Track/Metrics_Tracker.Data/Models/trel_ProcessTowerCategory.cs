namespace Metrics_Track.Data.Models
{
    public class trel_ProcessTowerCategory
    {
        public int IdPtg { get; set; }

        public int? IdProcess { get; set; }

        public int? IdTowerCategory { get; set; }

        public tbl_Process IdProcessNavigation { get; set; }

        public tbl_TowerCategory IdTowerCategoryNavigation { get; set; }
    }
}
