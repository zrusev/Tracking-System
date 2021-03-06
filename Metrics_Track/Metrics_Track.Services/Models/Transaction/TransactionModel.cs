﻿namespace Metrics_Track.Services.Models.Transaction
{
    using Common.Validation;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionModel
    {
        public int TransactionId { get; set; }

        public int? IdLogin { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredCountrySelection)]
        public int IdCountry { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredProcessSelection)]
        public int IdProcess { get; set; }

        public string Process { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredActivitySelection)]
        public int IdActivity { get; set; }

        public string Activity { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredLobSelection)]
        public int IdLob { get; set; }

        public string Lob { get; set; }

        public int? IdDivision { get; set; }

        public int? IdTowerCategory { get; set; }

        public int? IdTower { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredReceivedDate)]
        [DataType(DataType.Text)]
        public DateTime ReceivedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredStatusSelection)]
        public int IdStatus { get; set; }

        public string Status { get; set; }

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

        public short? Priority => this.IsPriority == true ? (short)1 : (short)0;

        [Display(Name = "High priority")]
        public bool IsPriority { get; set; }

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
        public DateTime? DateReceivedInAig { get; set; }

        public double? IdleHours { get; set; }
    }
}
