namespace Metrics_Track.Services.Implementations
{
    using Contracts;
    using Metrics_Track.Data.Models;
    using System;
    public class Transaction : ITransaction
    {
        private readonly TrackerDbContext db;

        public Transaction(TrackerDbContext db)
        {
            this.db = db;
        }

        public int AddTransaction(int loginId, int countryId, int processId, int activityId, int lobId, int divisionId, int towerCategoryId, int towerId, 
                                   DateTime receivedDate, DateTime startDate, DateTime completeDate, 
                                   int statusId, string comment, string numberId, string partnerId, string contactId, double premium, string currCode, 
                                   string insuredName, string tranRequestor, int? originalId, short statusCode, short priority, short sandbox, string attachments, 
                                   DateTime inceptionDate, DateTime dateReceived)
        {
            var currentTransaction = new tbl_VolumeMain
            {
                IdLogin = loginId,
                IdCountry = countryId,
                IdProcess = processId,
                IdActivity = activityId,
                IdLob = lobId,
                IdDivision = divisionId,                
                IdTowerCategory = towerCategoryId,
                IdTower = towerId,
                ReceivedDate = receivedDate,
                StartDate = startDate,
                CompleteDate = completeDate,
                IdStatus = statusId,
                Comment = comment,
                IdNumber = numberId,
                IdPartner = partnerId,
                IdContract = contactId,
                Premium = premium,
                CurrencyCode = currCode,
                InsuredName = insuredName,
                TransactionRequestor = tranRequestor,
                OriginalId = originalId,
                StatusCode = statusCode,
                Priority = priority,
                Sandbox = sandbox,
                Attachments = attachments,
                InceptionDate = inceptionDate,
                DateReceivedInAig = dateReceived
            };

            this.db.TblVolumeMain.Add(currentTransaction);
            this.db.SaveChanges();

            return currentTransaction.TransactionId;
        }
    }
}
