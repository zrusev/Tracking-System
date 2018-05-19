namespace Metrics_Track.Data.Models
{
    using System;
    public class tbl_VolumeMain
    {
        public int TransactionId { get; set; }
        public int? IdLogin { get; set; }
        public int? IdCountry { get; set; }
        public int? IdProcess { get; set; }
        public int? IdActivity { get; set; }
        public int? IdLob { get; set; }
        public int? IdDivision { get; set; }
        public int? IdTowerCategory { get; set; }
        public int? IdTower { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int? IdStatus { get; set; }
        public string Comment { get; set; }
        public string IdNumber { get; set; }
        public string IdPartner { get; set; }
        public string IdContract { get; set; }
        public double? Premium { get; set; }
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
        public DateTime? InceptionDate { get; set; }
        public DateTime? DateReceivedInAig { get; set; }
        public double? IdleHours { get; set; }

        public tbl_Activity IdActivityNavigation { get; set; }
        public tbl_Country IdCountryNavigation { get; set; }
        public tbl_Division IdDivisionNavigation { get; set; }
        public tbl_Lob IdLobNavigation { get; set; }
        public tbl_Login IdLoginNavigation { get; set; }
        public tbl_Process IdProcessNavigation { get; set; }
        public tbl_Status IdStatusNavigation { get; set; }
        public tbl_TowerCategory IdTowerCategoryNavigation { get; set; }
        public tbl_Tower IdTowerNavigation { get; set; }
    }
}
