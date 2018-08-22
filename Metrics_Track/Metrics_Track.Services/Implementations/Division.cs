namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Models;
    using Models.Division;
    using System.Collections.Generic;
    using System.Linq;

    public class Division : IDivision
    {
        private readonly TrackerDbContext db;

        public Division(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DivisionModel> All()
            => this.db
                .TblDivision
                .OrderBy(a => a.Division)
                .ProjectTo<DivisionModel>()
                .ToList();

        public DivisionModel ById(int id)
            => this.db
                .TblDivision
                .Where(i => i.IdDivision== id)
                .ProjectTo<DivisionModel>()
                .FirstOrDefault();

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
    }
}
