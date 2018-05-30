namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Transaction;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<List<DailyTransactionsListModel>> DailyTransactions(int idLogin)
        {
            string query = "SELECT TOP 10 [Transaction_ID],[Function Name],[Country],[Team Leader],[User Name],[Process],[Process Map],[Activity],[LOB],[ReceivedDate],[StartDate],[CompleteDate],[Comment],[ID_Number],[Status],[Premium],[Currency_Code],[MNC],[Priority],[SLA Hrs],[SLA Target],[SLA Type],[SLA Transaction],[SLA Achievment],[Handling Time],[Multi-Step Transaction],[Audit],[ID_Login],[AspID_Login] FROM [EMEAMRDB].[CPS].[SSC_View_MyTransactions] WHERE [AspID_Login] = {0} AND CompleteDate >= {1}";

            return await this.db
                     .SSCViewMyTransactions
                     .FromSql(query, idLogin, DateTime.Now.Date)
                     .AsNoTracking()
                     .ProjectTo<DailyTransactionsListModel>()
                     .ToListAsync();
        }

        public IEnumerable<PreviousTransactionModel> PreviousTransaction(int transactionId)
        =>  this.db
                .TblVolumeMain
                .Where(ti => ti.TransactionId == transactionId)
                .Select(s => new
                {
                    Premium = s.Premium,
                    ReceivedDate = s.ReceivedDate,
                    ProcessTrel = s.IdProcessNavigation,
                    LobTrel = s.IdLobNavigation,
                    StatusTrel = s.IdStatusNavigation
                }).Select(p => new PreviousTransactionModel
                {
                    Process = p.ProcessTrel.ProcessMap,
                    Lob = p.LobTrel.Lob,
                    Premium = p.Premium,
                    ReceivedDate = p.ReceivedDate,
                    DocId = transactionId,
                    Status = p.StatusTrel.Status
                });
    }
}
