namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Transaction;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Transaction : ITransaction
    {
        private const int CompleteTransactionIdStatusCode = 1;
        private const int PendingIdStatusCode = 5;
        private const int PendingTransactionCode = 2;

        private const int MaxResultsPerQuery = 500;

        private readonly TrackerDbContext db;

        public Transaction(TrackerDbContext db)
        {
            this.db = db;
        }

        public bool Exists(TransactionModel model)
             => (from trel in this.db.TrelCountryProcess
                 join c in this.db.TblCountry on trel.IdCountry equals c.IdCountry
                    where c.IdCountry == model.IdCountry
                 join p in this.db.TblProcess on trel.IdProcess equals p.IdProcess
                 join pa in this.db.TrelProcessActivity on p.IdProcess equals pa.IdProcess
                 join a in this.db.TblActivity on pa.IdActivity equals a.IdActivity
                    where a.IdActivity == model.IdActivity
                 join ps in this.db.TrelProcessStatus on p.IdProcess equals ps.IdProcess
                 join s in this.db.TblStatus on ps.IdStatus equals s.IdStatus
                    where s.IdStatus == model.IdStatus
                 join pl in this.db.TrelProcessLob on p.IdProcess equals pl.IdProcess
                 join l in this.db.TblLob on pl.IdLob equals l.IdLob
                    where l.IdLob == model.IdLob
                 //join pd in this.db.TrelProcessDivision on p.IdProcess equals pd.IdProcess
                 //join d in this.db.TblDivision on pd.IdDivision equals d.IdDivision
                 //   where d.IdDivision == model.IdDivision
                 //join pt in this.db.TrelProcessTower on p.IdProcess equals pt.IdProcess
                 //join t in this.db.TblTower on pt.IdTower equals t.IdTower
                 //   where pt.IdTower == model.IdTower
                 //join ptc in this.db.TrelProcessTowerCategory on p.IdProcess equals ptc.IdProcess
                 //join tc in this.db.TblTowerCategory on ptc.IdTowerCategory equals tc.IdTowerCategory
                 //   where ptc.IdTowerCategory == model.IdTowerCategory
                 select trel)
                .Any();

        public int AddTransaction(TransactionModel model)
        {
            if (model.IdStatus == PendingIdStatusCode)
            {
                model.StatusCode = PendingTransactionCode;
            }
            else
            {
                model.StatusCode = CompleteTransactionIdStatusCode;
            }

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
             => this.db
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

        public ICollection<AllTransactionsListModel> AllTransactions(DateTime receivedDate, DateTime completeDate)
        {
            string query = @"SELECT TOP ({0}) * 
                                         FROM [CPS].[SSC_View_Reporting] 
                                        WHERE [Complete Date] >= {1} 
                                          AND [Complete Date] < {2} 
                                     ORDER BY [Transaction ID] DESC";

            return this.db
                     .SCCViewReporting
                     .FromSql(query, MaxResultsPerQuery, receivedDate, completeDate)
                     .AsNoTracking()
                     .ProjectTo<AllTransactionsListModel>()
                     .ToList();
        }
    }
}
