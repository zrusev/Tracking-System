namespace Metrics_Track.Services.Models.Transaction
{
    using System;
    public class PendingListModel
    {
        public int? IdProcess { get; set; }

        public string Process { get; set; }

        public int? IdLob { get; set; }

        public string Lob { get; set; }

        public string IdNumber { get; set; }

        public double? Premium { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int TransactionId { get; set; }

        public int? IdStatus { get; set; }

        public string Status { get; set; }
    }
}
