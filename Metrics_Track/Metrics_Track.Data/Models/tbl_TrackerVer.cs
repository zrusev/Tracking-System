namespace Metrics_Track.Data.Models
{
    using System;

    public class tbl_TrackerVer
    {
        public int Id { get; set; }

        public DateTime? ChangeStamp { get; set; }

        public string Request { get; set; }

        public string Change { get; set; }

        public string Version { get; set; }
    }
}
