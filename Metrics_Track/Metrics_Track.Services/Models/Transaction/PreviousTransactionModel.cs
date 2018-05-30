using System;

namespace Metrics_Track.Services.Models.Transaction
{
    public class PreviousTransactionModel
    {
        public string Process { get; set; }

        public string Lob { get; set; }

        public double? Premium { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int DocId { get; set; }

        public string Status { get; set; }
    }
}
