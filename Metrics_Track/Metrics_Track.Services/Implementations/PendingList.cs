namespace Metrics_Track.Services.Implementations
{
    using Contracts;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Transaction;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PendingList : IPendingList
    {
        private readonly TrackerDbContext db;

        public PendingList(TrackerDbContext db)
        {
            this.db = db;
        }

        public async Task<List<PendingListModel>> AllAsync(int idLogin, short statusCode, short sandbox)
        => await this.db
                .TblVolumeMain
                .Where(d => d.IdLogin == idLogin && d.StatusCode == statusCode && d.Sandbox == sandbox)
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
                .OrderBy(d => d.TransactionId)
                .ToListAsync();
    }
}
