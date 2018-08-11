namespace Metrics_Track.Areas.Management.Pages
{
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Services.Models.Transaction;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ReportingModel : ManagementModel
    {
        private readonly ITransaction transaction;

        public ReportingModel(ITransaction transaction)
        {
            this.transaction = transaction;
            this.AllTransactions = new List<AllTransactionsListModel>();
            this.ReceivedDate = DateTime.Today.AddMonths(-1);
            this.CompleteDate = DateTime.Today.AddDays(1);
        }

        public IEnumerable<AllTransactionsListModel> AllTransactions { get; set; }

        [BindProperty]
        [Display(Name = "Received Date")]
        public DateTime ReceivedDate { get; set; }

        [BindProperty]
        [Display(Name = "Complete Date")]
        public DateTime CompleteDate { get; set; }

        public void OnPost()
        {
            this.AllTransactions = this.transaction.AllTransactions(this.ReceivedDate, this.CompleteDate);
        }
    }
}