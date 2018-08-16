namespace Metrics_Track.Web.Models
{
    using Metrics_Track.Services.Models.Transaction;
    using System.Collections.Generic;

    public class DailyTransactionsViewModel
    {
        public List<DailyTransactionsListModel> DailyTransactionsList { get; set; } = new List<DailyTransactionsListModel>();
    }
}
