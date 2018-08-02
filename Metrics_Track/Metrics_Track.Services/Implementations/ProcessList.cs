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

        public int[] Ids(int id)
            => this.db
                .TrelCountryProcess
                .Where(i => i.IdCountry == id)
                .Select(s => (int)s.IdProcess)
                .ToArray();

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

        public int AddProcess(ProcessListModel model)
        {
            var process = new tbl_Process()
            {
                Process = model.Process,
                FunctionName = model.FunctionName,
                ProcessMap = model.ProcessMap,
                Mnc = model.Mnc,
                SlaType = model.SlaType,
                SlaTarget = model.SlaTarget,
                Level2Taxonomy = model.Level2Taxonomy,
                Level3Taxonomy = model.Level3Taxonomy,
                Pid = model.Pid,
                NiceQueue = model.NiceQueue,
                Group = model.Group,
                SpphIdProcess = model.SpphIdProcess
            };

            this.db.TblProcess.Add(process);
            this.db.SaveChanges();

            return process.IdProcess;
        }

        public void RemoveProcess(int id)
        {
            var process = this.db
                .TblProcess
                .Where(i => i.IdProcess == id)
                .FirstOrDefault();

            this.db.TblProcess.Remove(process);
            this.db.SaveChanges();
        }

        public void UpdateCountryProcessIds(int idCountry, int[] ids)
        {
            var currentIds = this.db
                .TrelCountryProcess
                .Where(i => i.IdCountry == idCountry)
                .ToList();

            if (currentIds.Count > 0)
            {
                this.db.TrelCountryProcess.RemoveRange(currentIds);
            }
            
            var newMap = ids.SelectMany(p => new int[] { idCountry },
                                       (p, c) => new trel_CountryProcess { IdCountry = c, IdProcess = p });
 
            this.db.TrelCountryProcess.AddRange(newMap);
            this.db.SaveChanges();
        }

        public void UpdateProcessLobIds(int idProcess, int[] ids)
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

        public void UpdateProcessActivityIds(int idProcess, int[] ids)
        {
            var currentIds = this.db
                .TrelProcessActivity
                .Where(i => i.IdProcess == idProcess)
                .ToList();

            if (currentIds.Count > 0)
            {
                this.db.TrelProcessActivity.RemoveRange(currentIds);
            }

            var newMap = ids.SelectMany(p => new int[] { idProcess },
                                       (p, c) => new trel_ProcessActivity { IdProcess = c, IdActivity = p });

            this.db.TrelProcessActivity.AddRange(newMap);
            this.db.SaveChanges();
        }
    }
}
