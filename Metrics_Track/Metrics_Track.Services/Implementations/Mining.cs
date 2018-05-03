namespace Metrics_Track.Services.Implementations
{
    using Metrics_Track.Data.Models;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    public class Mining : IMining
    {
        private readonly TrackerDbContext db;

        public Mining(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<MiningDataModel> ById(int id)
        {
            var minings = this.db.TblMining
                        .Where(t => t.TrelUserMining.Any(i => i.IdLogin == id))
                        .Select(m => new MiningDataModel
                        {
                            IdMining = m.IdMining,
                            State = m.State
                        })
                        .ToList();

            return minings;
        }
    }
}
