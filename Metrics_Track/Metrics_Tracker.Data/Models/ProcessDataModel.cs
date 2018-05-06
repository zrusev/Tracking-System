namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class ProcessDataModel
    {
        public int ID_Process{ get; set; }

        public string Process { get; set; }

        public List<StatusDataModel> StatusList { get; set; }

        public List<ActivityDataModel> ActivityList { get; set; }

        public List<LobDataModel> LobList { get; set; }

        public ProcessDataModel()
        {
            this.StatusList = new List<StatusDataModel>();
            this.ActivityList = new List<ActivityDataModel>();
            this.LobList = new List<LobDataModel>();
          }
    }
}
