namespace Metrics_Track.Services.Contracts
{
    using Metrics_Track.Data.Models;
    using Metrics_Track.Services.Models.Transaction;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ITransaction
    {
        int AddTransaction(TransactionModel model);

        Task<List<DailyTransactionsListModel>> DailyTransactions(int idLogin);
    }
}
