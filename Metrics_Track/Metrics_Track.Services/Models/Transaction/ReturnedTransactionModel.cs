namespace Metrics_Track.Services.Models.Transaction
{
    using System;
    public class ReturnedTransactionModel
    {
        public int TransactionId { get; set; }

        public int? IdLogin { get; set; }

        public int? IdCountry { get; set; }

        public int? IdProcess { get; set; }

        public string Process { get; set; }

        public int? IdActivity { get; set; }

        public string Activity { get; set; }

        public int? IdLob { get; set; }

        public string Lob { get; set; }

        public int? IdDivision { get; set; }

        public int? IdTowerCategory { get; set; }

        public int? IdTower { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public int? IdStatus { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }

        public string IdNumber { get; set; }

        public string IdPartner { get; set; }

        public string IdContract { get; set; }

        public double? Premium { get; set; }

        public string CurrencyCode { get; set; }

        public string InsuredName { get; set; }

        public int? OriginalId { get; set; }

        public short? StatusCode { get; set; }

        public short? Priority { get; set; }

        public short Sandbox { get; set; }

        public DateTime? InceptionDate { get; set; }

        public DateTime? DateReceivedInAig { get; set; }
    }
}
