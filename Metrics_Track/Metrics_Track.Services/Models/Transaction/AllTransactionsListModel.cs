namespace Metrics_Track.Services.Models.Transaction
{
    using System;

    public class AllTransactionsListModel
    {
        public int TransactionId { get; set; }

        public string FunctionName { get; set; }

        public string Country { get; set; }

        public string TeamLead { get; set; }

        public string UserName { get; set; }

        public string Process { get; set; }

        public string ProcessMap { get; set; }

        public string Activity { get; set; }

        public string Lob { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public string Comment { get; set; }

        public string ID_Number { get; set; }

        public string Status { get; set; }

        public double? Premium { get; set; }

        public string CurrencyCode { get; set; }

        public short? Priority { get; set; }

        public DateTime? InceptionDate { get; set; }

        public DateTime? DateReceivedInAig { get; set; }

        public double SlaHrs { get; set; }

        public int SlaTarget { get; set; }

        public string SlaType { get; set; }

        public int SlaAchievement { get; set; }

        public double HandlingTime { get; set; }

        public string Week { get; set; }

        public string Month { get; set; }

        public short Sandbox { get; set; }
    }
}
