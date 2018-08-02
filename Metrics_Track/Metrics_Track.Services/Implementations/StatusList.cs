namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Status;
    using System.Collections.Generic;
    using System.Linq;

    public class StatusList : IStatusList
    {
        private readonly TrackerDbContext db;

        public StatusList(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<StatusModel> All()
            => this.db
                .TblStatus
                .OrderBy(s => s.Status)
                .ProjectTo<StatusModel>()
                .ToList();

        public StatusModel ById(int id)
            => this.db
                .TblStatus
                .Where(i => i.IdStatus == id)
                .ProjectTo<StatusModel>()
                .FirstOrDefault();

        public int[] Ids(int id)
             => this.db
                .TrelProcessStatus
                .Where(i => i.IdProcess == id)
                .Select(s => (int)s.IdStatus)
                .ToArray();

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
            var status = this.db
                .TblStatus
                .Where(i => i.IdStatus == id)
                .FirstOrDefault();

            this.db.TblStatus.Remove(status);
            this.db.SaveChanges();
        }

        public void UpdateIds(int idProcess, int[] ids)
        {
            var currentIds = this.db
                .TrelProcessStatus
                .Where(i => i.IdProcess == idProcess)
                .ToList();

            if (currentIds.Count > 0)
            {
                this.db.TrelProcessStatus.RemoveRange(currentIds);
            }

            var newMap = ids.SelectMany(p => new int[] { idProcess },
                                       (p, c) => new trel_ProcessStatus { IdProcess = c, IdStatus = p });

            this.db.TrelProcessStatus.AddRange(newMap);
            this.db.SaveChanges();
        }
    }
}
