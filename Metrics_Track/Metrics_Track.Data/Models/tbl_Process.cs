﻿namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;

    public class tbl_Process
    {
        public tbl_Process()
        {
            this.TblVolumeMain = new HashSet<tbl_VolumeMain>();
            this.TrelCountryProcess = new HashSet<trel_CountryProcess>();
            this.TrelProcessActivity = new HashSet<trel_ProcessActivity>();
            this.TrelProcessDivision = new HashSet<trel_ProcessDivision>();
            this.TrelProcessLob = new HashSet<trel_ProcessLob>();
            this.TrelProcessStatus = new HashSet<trel_ProcessStatus>();
            this.TrelProcessTower = new HashSet<trel_ProcessTower>();
            this.TrelProcessTowerCategory = new HashSet<trel_ProcessTowerCategory>();
        }

        public int IdProcess { get; set; }

        public string Process { get; set; }

        public string FunctionName { get; set; }

        public string ProcessMap { get; set; }

        public string Mnc { get; set; }

        public string SlaType { get; set; }

        public string SlaTarget { get; set; }

        public string Level2Taxonomy { get; set; }

        public string Level3Taxonomy { get; set; }

        public string Pid { get; set; }

        public string NiceQueue { get; set; }

        public string Group { get; set; }

        public int? SpphIdProcess { get; set; }

        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }

        public ICollection<trel_CountryProcess> TrelCountryProcess { get; set; }

        public ICollection<trel_ProcessActivity> TrelProcessActivity { get; set; }

        public ICollection<trel_ProcessDivision> TrelProcessDivision { get; set; }

        public ICollection<trel_ProcessLob> TrelProcessLob { get; set; }

        public ICollection<trel_ProcessStatus> TrelProcessStatus { get; set; }

        public ICollection<trel_ProcessTower> TrelProcessTower { get; set; }

        public ICollection<trel_ProcessTowerCategory> TrelProcessTowerCategory { get; set; }
    }
}
