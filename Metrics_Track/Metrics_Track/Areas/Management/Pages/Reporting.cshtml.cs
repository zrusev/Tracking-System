namespace Metrics_Track.Areas.Management.Pages
{
    using Metrics_Track.Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Services.Models.Transaction;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using X.PagedList;

    public class ReportingModel : ManagementModel
    {
        private readonly ITransaction transaction;

        public ReportingModel(ITransaction transaction)
        {
            this.transaction = transaction;
            this.AllTransactions = new List<AllTransactionsListModel>();
            this.PagedTransactions = new List<AllTransactionsListModel>();
            this.ReceivedDate = DateTime.Today.AddMonths(-1);
            this.CompleteDate = DateTime.Today.AddDays(1);
        }
        
        public ICollection<AllTransactionsListModel> AllTransactions { get; set; }

        public IEnumerable<AllTransactionsListModel> PagedTransactions { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Received Date"), DataType(DataType.DateTime)]
        public DateTime ReceivedDate { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Complete Date"), DataType(DataType.DateTime)]
        public DateTime CompleteDate { get; set; }

        public IActionResult OnGet(int? id, DateTime? receivedDate, DateTime? completeDate)
        {
            if (id != null)
            {
                TransactionsHandler(id, receivedDate, completeDate);
            }

            return Page();
        }

        public void OnPostResults(int? id)
        {
            if (ReceivedDate >= CompleteDate)
            {
                TempData.AddErrorMessage("Received Date can not be later than Complete Date.");
            }

            TransactionsHandler(id, null, null);
        }

        private void TransactionsHandler(int? id, DateTime? receiveDate, DateTime? completeDate)
        {
            var pageNumber = id ?? 1;

            var rDate = receiveDate != null ? (DateTime)receiveDate : this.ReceivedDate;
            var cDate = completeDate != null ? (DateTime)completeDate : this.CompleteDate;
            
            this.AllTransactions = this.transaction.AllTransactions(rDate, cDate);
            TempData.Put<string>("inputMessage", $"Successfully exported {this.AllTransactions.Count} transactions!");

            this.PagedTransactions = this.AllTransactions.ToPagedList(pageNumber, WebConstants.MaxItemsPerPage);
        }

        public IActionResult OnPostDownload()
        {
            TempData.Put<string>("ReceivedDate", ReceivedDate.ToString());
            TempData.Put<string>("CompleteDate", CompleteDate.ToString());
            TempData.Put<string>("fileName", $"_{ReceivedDate.ToShortDateString().Replace('/', '_')}_{CompleteDate.ToShortDateString().Replace('/', '_')}");            

            return RedirectToPage("/FileHandler");
        }
    }
}