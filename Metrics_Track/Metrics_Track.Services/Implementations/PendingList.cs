namespace Metrics_Track.Services.Implementations
{
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Transaction;
    using System.Collections.Generic;
    using System.Linq;

    public class PendingList : IPendingList
    {
        private readonly TrackerDbContext db;

        public PendingList(TrackerDbContext db)
        {
            this.db = db;
        }

        public List<PendingListModel> All(short statusCode, short sandbox)
        => this.db.TblVolumeMain
                .Where(d => d.IdLogin == 145 &&  d.StatusCode == statusCode && d.Sandbox == sandbox)
                .Select(t => new PendingListModel
                {
                    IdProcess = t.IdProcess,
                    Process = t.IdProcessNavigation.ProcessMap,
                    IdLob = t.IdLob,
                    Lob = t.IdLobNavigation.Lob,
                    IdNumber = t.IdNumber,
                    TransactionId = t.TransactionId,
                    Premium = t.Premium,
                    ReceivedDate = t.ReceivedDate,
                    IdStatus = t.IdStatus,
                    Status = t.IdStatusNavigation.Status
                })
                .OrderByDescending(d => d.TransactionId)
                .ToList();
    }
}
