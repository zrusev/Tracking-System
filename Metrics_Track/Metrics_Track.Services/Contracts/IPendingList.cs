namespace Metrics_Track.Services.Contracts
{
    using Models.Transaction;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPendingList
    {
        Task<List<PendingListModel>> AllAsync(short statusCode, short sandbox);
    }
}