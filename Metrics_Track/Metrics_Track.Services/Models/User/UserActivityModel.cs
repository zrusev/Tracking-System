namespace Metrics_Track.Services.Models.User
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;
    using System;

    public class UserActivityModel : IMapFrom<tbl_UserActivity>
    {
        public int? IdLogin { get; set; }

        public string Type { get; set; }

        public DateTime? ChangeStamp { get; set; }

        public string Comment { get; set; }

        public short Sandbox { get; set; }

        public string MetricsTrackVer { get; set; }
    }
}
