namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;

    public class tbl_Mining
    {
        public tbl_Mining()
        {
            this.TrelUserMining = new List<trel_UserMining>();
            this.Countries = new List<trel_CountryMining>();
        }

        public int IdMining { get; set; }

        public string State { get; set; }

        public List<trel_UserMining> TrelUserMining { get; set; }

        public List<trel_CountryMining> Countries { get; set; }
    }
}
