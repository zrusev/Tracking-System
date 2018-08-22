namespace Metrics_Track.Web.Models
{
    using Services.Models.Transaction;
    using System.Collections.Generic;

    public class DailyTransactionsViewModel
    {
        public List<DailyTransactionsListModel> DailyTransactionsList { get; set; } = new List<DailyTransactionsListModel>();
    }
}
