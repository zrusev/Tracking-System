namespace Metrics_Track.Services.Models.Process
{
    using Activity;
    using Lob;
    using Status;
    using System.Collections.Generic;

    public class ProcessModel
    {
        public ProcessModel()
        {
            this.StatusList = new List<StatusModel>();
            this.ActivityList = new List<ActivityModel>();
            this.LobList = new List<LobModel>();
        }

        public int ID_Process { get; set; }

        public string Process { get; set; }

        public List<StatusModel> StatusList { get; set; }

        public List<ActivityModel> ActivityList { get; set; }

        public List<LobModel> LobList { get; set; }
    }
}
