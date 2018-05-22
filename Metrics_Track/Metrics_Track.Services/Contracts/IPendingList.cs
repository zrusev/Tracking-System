namespace Metrics_Track.Services.Contracts
{
    using Models.Transaction;
    using System.Collections.Generic;

    public interface IPendingList
    {
        List<PendingListModel> All(short statusCode, short sandbox);
    }
}