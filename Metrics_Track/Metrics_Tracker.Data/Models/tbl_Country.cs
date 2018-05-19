namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Country
    {
        public tbl_Country()
        {
            this.TblVolumeMain = new List<tbl_VolumeMain>();
            this.TrelCountryProcess = new List<trel_CountryProcess>();
            this.TrelUserCountry = new List<trel_UserCountry>();
            this.Agents = new List<trel_AgentCountry>();
        }
        public int IdCountry { get; set; }
        public string Country { get; set; }
        public string RefSite { get; set; }
        public int? SpphIdCountry { get; set; }
        public List<tbl_VolumeMain> TblVolumeMain { get; set; }
        public List<trel_CountryProcess> TrelCountryProcess { get; set; }
        public List<trel_UserCountry> TrelUserCountry { get; set; }
        public List<trel_AgentCountry> Agents { get; set; }
    }
}
