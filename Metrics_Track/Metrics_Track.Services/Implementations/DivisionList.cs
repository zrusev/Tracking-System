namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Division;
    using System.Collections.Generic;
    using System.Linq;
    public class DivisionList : IDivisionList
    {
        private readonly TrackerDbContext db;

        public DivisionList(TrackerDbContext db)
        {
            this.db = db;
        }
        
        public IEnumerable<DivisionModel> All()
            => this.db
                .TblDivision
                .OrderBy(d => d.Division)
                .ProjectTo<DivisionModel>()
                .ToList();

        public DivisionModel ById(int id)
            => this.db
                .TblDivision
                .Where(i => i.IdDivision == id)
                .ProjectTo<DivisionModel>()
                .FirstOrDefault();

        public int[] Ids(int id)
             => this.db
                .TrelProcessDivision
                .Where(i => i.IdProcess == id)
                .Select(l => (int)l.IdDivision)
                .ToArray();

        public int UpdateDivision(DivisionModel model)
        {
            var division = this.db
                .TblDivision
                .Where(i => i.IdDivision == model.IdDivision)
                .FirstOrDefault();

            division.Division = model.Division;

            this.db.TblDivision.Update(division);
            this.db.SaveChanges();

            return division.IdDivision;
        }

        public int AddDivision(DivisionModel model)
        {
            var division = new tbl_Division()
            {
                Division = model.Division
            };

            this.db.TblDivision.Add(division);
            this.db.SaveChanges();

            return division.IdDivision;
        }

        public void RemoveDivision(int id)
        {
            var division = this.db
                .TblDivision
                .Where(i => i.IdDivision == id)
                .FirstOrDefault();

            this.db.TblDivision.Remove(division);
            this.db.SaveChanges();
        }

        public void UpdateIds(int idProcess, int[] ids)
        {
            var currentIds = this.db
                .TrelProcessDivision
                .Where(i => i.IdProcess == idProcess)
                .ToList();

            if (currentIds.Count > 0)
            {
                this.db.TrelProcessDivision.RemoveRange(currentIds);
            }

            var newMap = ids.SelectMany(p => new int[] { idProcess },
                                       (p, c) => new trel_ProcessDivision { IdProcess = c, IdDivision = p });

            this.db.TrelProcessDivision.AddRange(newMap);
            this.db.SaveChanges();
        }
    }
}
