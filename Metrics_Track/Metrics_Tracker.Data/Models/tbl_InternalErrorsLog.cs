namespace Metrics_Track.Data.Models
{
    using System;
    public class tbl_InternalErrorsLog
    {
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
}
