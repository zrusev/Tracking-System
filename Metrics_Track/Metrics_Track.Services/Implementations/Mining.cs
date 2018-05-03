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

        public IEnumerable<tbl_Mining> ById(int id)
        {
            var qry = from min in this.db.TblMining
                      from trl in this.db.TrelUserMining
                        .Where(t => min.IdMining == t.IdMining && t.IdLogin == (id))
                        .DefaultIfEmpty()
                      select new tbl_Mining() {
                          IdMining = min.IdMining,
                          State = min.State
                      };

            return qry;
        }
    }
}
