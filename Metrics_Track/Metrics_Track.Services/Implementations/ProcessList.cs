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
            .OrderBy(f => f.FunctionName)
            .ThenBy(p => p.Process)
            .ProjectTo<ProcessListModel>()
            .ToList();

        public ProcessListModel ById(int id)
            => this.db
            .TblProcess
            .Where(i => i.IdProcess == id)
            .ProjectTo<ProcessListModel>()
            .FirstOrDefault();

        public int UpdateProcess(ProcessListModel model)
        {
            var process = this.db
                .TblProcess
                .Where(i => i.IdProcess == model.IdProcess)
                .FirstOrDefault();

            process.Process = model.Process;
            process.FunctionName = model.FunctionName;
            process.ProcessMap = model.ProcessMap;
            process.Mnc = model.Mnc;
            process.SlaType = model.SlaType;
            process.SlaTarget = model.SlaTarget;
            process.Level2Taxonomy = model.Level2Taxonomy;
            process.Level3Taxonomy = model.Level3Taxonomy;
            process.Pid = model.Pid;
            process.NiceQueue = model.NiceQueue;
            process.Group = model.Group;
            process.SpphIdProcess = model.SpphIdProcess;

            this.db.TblProcess.Update(process);
            this.db.SaveChanges();

            return process.IdProcess;
        }
    }
}
