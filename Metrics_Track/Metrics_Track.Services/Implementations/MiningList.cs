namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Models;
    using Models.Mining;
    using System.Collections.Generic;
    using System.Linq;

    public class MiningList : IMiningList
    {
        private readonly TrackerDbContext db;

        public MiningList(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<MiningModel> All()
            => this.db
                .TblMining
                .OrderBy(s => s.State)
                .ProjectTo<MiningModel>()
                .ToList();

        public MiningModel ById(int id)
            => this.db
                .TblMining
                .Where(i => i.IdMining == id)
                .ProjectTo<MiningModel>()
                .FirstOrDefault();

        public int[] Ids(int id)
             => this.db
                .TrelCountryMining
                .Where(i => i.IdCountry == id)
                .Select(s => (int)s.IdMining)
                .ToArray();

        public int UpdateMining(MiningModel model)
        {
            var mining = this.db
                .TblMining
                .Where(i => i.IdMining == model.IdMining)
                .FirstOrDefault();

            mining.State = model.State;

            this.db.TblMining.Update(mining);
            this.db.SaveChanges();

            return mining.IdMining;
        }

        public int AddMining(MiningModel model)
        {
            var mining = new tbl_Mining()
            {
                State = model.State
            };

            this.db.TblMining.Add(mining);
            this.db.SaveChanges();

            return mining.IdMining;
        }
        
        public void RemoveMining(int id)
        {
            var mining = this.db
                .TblMining
                .Where(i => i.IdMining == id)
                .FirstOrDefault();

            this.db.TblMining.Remove(mining);
            this.db.SaveChanges();
        }

        public void UpdateIds(int idCountry, int[] ids)
        {
            var currentIds = this.db
                .TrelCountryMining
                .Where(i => i.IdCountry == idCountry)
                .ToList();

            if (currentIds.Count > 0)
            {
                this.db.TrelCountryMining.RemoveRange(currentIds);
            }

            var newMap = ids.SelectMany(p => new int[] { idCountry },
                                       (p, c) => new trel_CountryMining { IdCountry = c, IdMining = p });

            this.db.TrelCountryMining.AddRange(newMap);
            this.db.SaveChanges();
        }
    }
}