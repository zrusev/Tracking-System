namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Login
    {
        public tbl_Login()
        {
            TblUserActivity = new HashSet<tbl_UserActivity>();
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelUserCountry = new HashSet<trel_UserCountry>();
            TrelUserMining = new HashSet<trel_UserMining>();
        }

        public int IdLogin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TeamLead { get; set; }
        public string ServerName { get; set; }
        public string DisplayName { get; set; }
        public short Sandbox { get; set; }
        public string Site { get; set; }
        public int? SsphIdUser { get; set; }
        public ICollection<tbl_UserActivity> TblUserActivity { get; set; }
        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_UserCountry> TrelUserCountry { get; set; }
        public ICollection<trel_UserMining> TrelUserMining { get; set; }
    }
}
