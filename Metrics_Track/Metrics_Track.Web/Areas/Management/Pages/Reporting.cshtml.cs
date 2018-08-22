namespace Metrics_Track.Web.Areas.Management.Pages
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Services.Models.Transaction;
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
        }
        
        public ICollection<AllTransactionsListModel> AllTransactions { get; set; }

        public IEnumerable<AllTransactionsListModel> PagedTransactions { get; set; }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Received Date"), DataType(DataType.Text)]
        public DateTime ReceivedDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Complete Date"), DataType(DataType.Text)]
        public DateTime CompleteDate { get; set; } = DateTime.Now;

        public IActionResult OnGet(int? id, DateTime? receivedDate, DateTime? completedate)
        {
            if (receivedDate != null)
            {
                this.ReceivedDate = (DateTime)receivedDate;
            }

            if (completedate != null)
            {
                this.CompleteDate = (DateTime)completedate;
            }

            if (this.ReceivedDate >= this.CompleteDate)
            {
                TempData.AddErrorMessage("Received date can not be later than Complete date.");
                return Page();
            }
            
            var pageNumber = id ?? 1;

            this.AllTransactions = this.transaction.AllTransactions(this.ReceivedDate, this.CompleteDate);

            TempData.Put<string>("inputMessage", $"Successfully exported {this.AllTransactions.Count} transactions. Please wait. Generating file...");

            this.PagedTransactions = this.AllTransactions.ToPagedList(pageNumber, WebConstants.MaxItemsPerPage);

            return Page();
        }

        public IActionResult OnGetDownload(DateTime receivedDate, DateTime completeDate)
        {
            TempData.Put<string>("ReceivedDate", receivedDate.ToString());
            TempData.Put<string>("CompleteDate", completeDate.ToString());

            return RedirectToPage("/FileHandler");
        }
    }
}