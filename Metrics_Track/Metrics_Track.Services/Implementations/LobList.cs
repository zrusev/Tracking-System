namespace Metrics_Track.Services.Implementations
{
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Lob;
    using System.Collections.Generic;
    using System.Linq;

    public class LobList : ILobList
    {
        private readonly TrackerDbContext db;

        public LobList(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LobModel> All()
            => this.db
                .TblLob
                .OrderBy(l => l.Lob)
                .Select(m => new LobModel
                {
                    ID_Lob = m.IdLob,
                    Lob = m.Lob
                })
                .ToList();

        public LobModel ById(int id)
            => this.db
                .TblLob
                .Where(i => i.IdLob == id)
                .Select(m => new LobModel
                {
                    ID_Lob = m.IdLob,
                    Lob = m.Lob
                })
                .FirstOrDefault();

        public int[] Ids(int id)
             => this.db
                .TrelProcessLob
                .Where(i => i.IdProcess == id)
                .Select(l => (int)l.IdLob)
                .ToArray();

        public int UpdateLob(LobModel model)
        {
            var lob = this.db
                .TblLob
                .Where(i => i.IdLob == model.ID_Lob)
                .FirstOrDefault();

            lob.Lob = model.Lob;

            this.db.TblLob.Update(lob);
            this.db.SaveChanges();

            return lob.IdLob;
        }

        public int AddLob(LobModel model)
        {
            var lob = new tbl_Lob()
            {
                Lob = model.Lob
            };

            this.db.TblLob.Add(lob);
            this.db.SaveChanges();

            return lob.IdLob;
        }

        public void RemoveLob(int id)
        {
            var lob = this.db
                .TblLob
                .Where(i => i.IdLob== id)
                .FirstOrDefault();

            this.db.TblLob.Remove(lob);
            this.db.SaveChanges();
        }

        public void UpdateIds(int idProcess, int[] ids)
        {
            var currentIds = this.db
                .TrelProcessLob
                .Where(i => i.IdProcess == idProcess)
                .ToList();

            if (currentIds.Count > 0)
            {
                this.db.TrelProcessLob.RemoveRange(currentIds);
            }

            var newMap = ids.SelectMany(p => new int[] { idProcess },
                                       (p, c) => new trel_ProcessLob { IdProcess = c, IdLob = p });

            this.db.TrelProcessLob.AddRange(newMap);
            this.db.SaveChanges();
        }
    }
}
