namespace Metrics_Track.Services.Models.Transaction
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class TransactionModel
    {
        public int TransactionId { get; set; }

        public int? IdLogin { get; set; }

        [Required(ErrorMessage ="Country selection is required.")]
        public int IdCountry { get; set; }

        [Required(ErrorMessage = "Process selection is required.")]
        public int IdProcess { get; set; }

        [Required(ErrorMessage = "Activity selection is required.")]
        public int IdActivity { get; set; }

        [Required(ErrorMessage = "LOB selection is required.")]
        public int IdLob { get; set; }

        public int? IdDivision { get; set; }

        public int? IdTowerCategory { get; set; }

        public int? IdTower { get; set; }

        [Required(ErrorMessage = "Received date is required.")]
        [DataType(DataType.Text)]
        public DateTime ReceivedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        [Required(ErrorMessage = "Status selection is required.")]
        public int IdStatus { get; set; }

        public string Comment { get; set; }

        public string IdNumber { get; set; }

        public string IdPartner { get; set; }

        public string IdContract { get; set; }

        [Required(ErrorMessage = "Premium amount is required.")]
        public double Premium { get; set; }

        public string CurrencyCode { get; set; }

        public string WorkCode { get; set; }

        public string InsuredName { get; set; }

        public string TransactionRequestor { get; set; }

        public int? OriginalId { get; set; }

        public short? StatusCode { get; set; }

        public short? Priority { get; set; }

        public string Attachments { get; set; }

        public double? PrecalcSlaHours { get; set; }

        public double? PrecalcHt { get; set; }

        public short Sandbox { get; set; }

        public double? QualityPtsScored { get; set; }

        public double? QualityPtsTotal { get; set; }

        public string QualityReviewer { get; set; }

        public DateTime? QualityInspectionDate { get; set; }

        [DataType(DataType.Text)]
        public DateTime? InceptionDate { get; set; }

        [DataType(DataType.Text)]
        public DateTime? DateReceived { get; set; }

        public double? IdleHours { get; set; }
    }
}
