namespace Metrics_Track.Services.Models.Transaction
{
    using System;
    public class DailyTransactionsListModel
    {
        public int TransactionId { get; set; }

        public string FunctionName { get; set; }

        public string Country { get; set; }

        public string TeamLeader { get; set; }

        public string UserName { get; set; }

        public string Process { get; set; }

        public string ProcessMap { get; set; }

        public string Activity { get; set; }

        public string Lob { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public string Comment { get; set; }

        public string IdNumber { get; set; }

        public string Status { get; set; }

        public double? Premium { get; set; }

        public string CurrencyCode { get; set; }

        public string Mnc { get; set; }

        public short? Priority { get; set; }

        public double? SLAHrs { get; set; }

        public int? SLATarget { get; set; }

        public string SLAType { get; set; }

        public int SLATransaction { get; set; }

        public int SLAAchievment { get; set; }

        public double? HandlingTime { get; set; }

        public int MultiStepTransaction { get; set; }

        public int Audit { get; set; }

        public int? IdLogin { get; set; }

    }
}
