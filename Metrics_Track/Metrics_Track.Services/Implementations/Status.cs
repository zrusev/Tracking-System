namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Status;
    using System.Collections.Generic;
    using System.Linq;

    public class Status : IStatus
    {
        private readonly TrackerDbContext db;

        public Status(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<StatusModel> All()
            => this.db
                .TblStatus
                .OrderBy(a => a.Status)
                .ProjectTo<StatusModel>()
                .ToList();

        public StatusModel ById(int id)
            => this.db
                .TblStatus
                .Where(i => i.IdStatus == id)
                .ProjectTo<StatusModel>()
                .FirstOrDefault();

        public int UpdateStatus(StatusModel model)
        {
            var status = this.db
                .TblStatus
                .Where(i => i.IdStatus == model.IdStatus)
                .FirstOrDefault();

            status.Status = model.Status;

            this.db.TblStatus.Update(status);
            this.db.SaveChanges();

            return status.IdStatus;
        }

        public int AddStatus(StatusModel model)
        {
            var status = new tbl_Status()
            {
                Status = model.Status
            };

            this.db.TblStatus.Add(status);
            this.db.SaveChanges();

            return status.IdStatus;
        }

        public void RemoveStatus(int id)
        {
            var division = this.db
                .TblStatus
                .Where(i => i.IdStatus == id)
                .FirstOrDefault();

            this.db.TblStatus.Remove(division);
            this.db.SaveChanges();
        }

        public IEnumerable<CurrentStatusListModel> AllCurrentStatuses()
        {
            string query = @"SELECT [ID_Login], [Display Name], [Team Leader], [Type], [Last Update], [Comment], [Sandbox]
                               FROM [CPS].[SSC_View_UserCurrent]
                              WHERE Type <> 'Login'";

            return this.db
                .SSCViewCurrentStatus
                .FromSql(query)
                .AsNoTracking()
                .ProjectTo<CurrentStatusListModel>()
                .ToList();
        }
    }
}
