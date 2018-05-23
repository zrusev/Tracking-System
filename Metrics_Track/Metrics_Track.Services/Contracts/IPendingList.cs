namespace Metrics_Track.Services.Contracts
{
    using Models.Transaction;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPendingList
    {
        Task<List<PendingListModel>> AllAsync(int idLogin, short statusCode, short sandbox);
    }
}