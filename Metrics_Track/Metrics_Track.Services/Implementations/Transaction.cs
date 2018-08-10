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
            string query = @"SELECT [Transaction_ID], [Function Name], [Country], [Team Leader], [User Name], [Process], [Process Map], [Activity], [LOB], [ReceivedDate], 
                                    [StartDate], [CompleteDate], [Comment], [ID_Number], [Status], [Premium], [Currency_Code], [MNC], [Priority], [SLA Hrs], [SLA Target], 
                                    [SLA Type], [SLA Transaction], [SLA Achievment], [Handling Time], [Multi-Step Transaction], [Audit], [ID_Login], [AspID_Login] 
                               FROM [CPS].[SSC_View_MyTransactions] 
                              WHERE [AspID_Login] = {0} 
                                AND CompleteDate >= {1}";

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
                    .Select(p => new PreviousTransactionModel
                    {
                        Process = p.IdProcessNavigation.Process,
                        Lob = p.IdLobNavigation.Lob,
                        Premium = p.Premium,
                        ReceivedDate = p.ReceivedDate,
                        DocId = transactionId,
                        Status = p.IdStatusNavigation.Status
                    });

        public ReturnedTransactionModel ReturnedTransaction(int transactionId)
            => this.db
                .TblVolumeMain
                .Where(ti => ti.TransactionId == transactionId)
                .Select(t => new ReturnedTransactionModel
                {
                    TransactionId = t.TransactionId,
                    IdLogin = t.IdLogin,
                    IdCountry = t.IdCountry,
                    IdProcess = t.IdProcess,
                    Process = t.IdProcessNavigation.ProcessMap,
                    IdActivity = t.IdActivity,
                    Activity = t.IdActivityNavigation.Activity,
                    IdLob = t.IdLob,
                    Lob = t.IdLobNavigation.Lob,
                    IdDivision = t.IdDivision,
                    IdTowerCategory = t.IdTowerCategory,
                    IdTower = t.IdTower,
                    ReceivedDate = t.ReceivedDate,
                    IdStatus = t.IdStatus,
                    Status = t.IdStatusNavigation.Status,
                    Comment = t.Comment,
                    IdNumber = t.IdNumber,
                    IdPartner = t.IdPartner,
                    IdContract = t.IdContract,
                    Premium = t.Premium,
                    CurrencyCode = t.CurrencyCode,
                    InsuredName = t.InsuredName,
                    OriginalId = t.OriginalId,
                    StatusCode = t.StatusCode,
                    Priority = t.Priority,
                    Sandbox = t.Sandbox,
                    InceptionDate = t.InceptionDate,
                    DateReceivedInAig = t.DateReceivedInAig
                })
                .FirstOrDefault();

        public void UpdateStatusCode(int transactionId, short statusCode)
        {
            var transaction = this.db
                    .TblVolumeMain
                    .Where(ti => ti.TransactionId == transactionId)              
                    .FirstOrDefault();

            transaction.StatusCode = statusCode;

            this.db.TblVolumeMain.Update(transaction);
            this.db.SaveChanges();
        }
    }
}
