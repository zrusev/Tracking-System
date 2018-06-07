namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Metrics_Track.Data.Models;
    using Models.Process;
    using System.Collections.Generic;
    using System.Linq;
    public class ProcessList : IProcessList
    {
        private readonly TrackerDbContext db;

        public ProcessList(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ProcessListModel> All()
            => this.db
            .TblProcess
            .ProjectTo<ProcessListModel>()
            .ToList();
    }
}
