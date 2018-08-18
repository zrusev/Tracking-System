namespace Metrics_Track.Data.Models
{
    using System;

    public class tbl_UserActivity
    {
        public int IdUserActivity { get; set; }

        public int? IdLogin { get; set; }

        public string Type { get; set; }

        public DateTime? ChangeStamp { get; set; }

        public string Comment { get; set; }

        public short Sandbox { get; set; }

        public string MetricsTrackVer { get; set; }

        public tbl_Login IdLoginNavigation { get; set; }
    }
}
