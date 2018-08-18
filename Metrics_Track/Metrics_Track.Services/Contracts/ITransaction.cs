namespace Metrics_Track.Services.Contracts
{
    using Models.Transaction;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransaction
    {
        int AddTransaction(TransactionModel model);

        Task<List<DailyTransactionsListModel>> DailyTransactions(int idLogin);

        IEnumerable<PreviousTransactionModel> PreviousTransaction(int transactionId);

        ReturnedTransactionModel ReturnedTransaction(int transactionId);

        void UpdateStatusCode(int transactionId, short statusCode);

        ICollection<AllTransactionsListModel> AllTransactions(DateTime receivedDate, DateTime completeDate);
    }
}
