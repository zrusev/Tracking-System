namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Country
    {
        public tbl_Country()
        {
            TblVolumeMain = new HashSet<tbl_VolumeMain>();
            TrelCountryProcess = new HashSet<trel_CountryProcess>();
            TrelUserCountry = new HashSet<trel_UserCountry>();
        }

        public int IdCountry { get; set; }
        public string Country { get; set; }
        public string RefSite { get; set; }
        public int? SpphIdCountry { get; set; }
        public ICollection<tbl_VolumeMain> TblVolumeMain { get; set; }
        public ICollection<trel_CountryProcess> TrelCountryProcess { get; set; }
        public ICollection<trel_UserCountry> TrelUserCountry { get; set; }
    }
}
