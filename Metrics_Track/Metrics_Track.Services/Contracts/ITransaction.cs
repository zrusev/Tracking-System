namespace Metrics_Track.Services.Contracts
{
    using Metrics_Track.Services.Models.Transaction;
    public interface ITransaction
    {
        int AddTransaction(TransactionModel model);
    }
}
