namespace Metrics_Track.Services.Implementations
{
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Transaction;
    public class Transaction : ITransaction
    {
        private readonly TrackerDbContext db;

        public Transaction(TrackerDbContext db)
        {
            this.db = db;
        }

        public int AddTransaction(TransactionModel model)
        {
            var currentTransaction = new tbl_VolumeMain
            {
                IdLogin = model.IdLogin,
                IdCountry = model.IdCountry,
                IdProcess = model.IdProcess,
                IdActivity = model.IdActivity,
                IdLob = model.IdLob,
                IdDivision = model.IdDivision,                
                IdTowerCategory = model.IdTowerCategory,
                IdTower = model.IdTower,
                ReceivedDate = model.ReceivedDate,
                StartDate = model.StartDate,
                CompleteDate = model.CompleteDate,
                IdStatus = model.IdStatus,
                Comment = model.Comment,
                IdNumber = model.IdNumber,
                IdPartner = model.IdPartner,
                IdContract = model.IdContract,
                Premium = model.Premium,
                CurrencyCode = model.CurrencyCode,
                InsuredName = model.InsuredName,
                TransactionRequestor = model.TransactionRequestor,
                OriginalId = model.OriginalId,
                StatusCode = model.StatusCode,
                Priority = model.Priority,
                Sandbox = model.Sandbox,
                Attachments = model.Attachments,
                InceptionDate = model.InceptionDate,
                DateReceivedInAig = model.DateReceivedInAig
            };

            this.db.TblVolumeMain.Add(currentTransaction);
            this.db.SaveChanges();

            return currentTransaction.TransactionId;
        }
    }
}
