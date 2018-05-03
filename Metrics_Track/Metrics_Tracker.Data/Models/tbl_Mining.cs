namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class tbl_Mining
    {
        public tbl_Mining()
        {
            TrelUserMining = new HashSet<trel_UserMining>();
        }

        public int IdMining { get; set; }
        public string State { get; set; }
        public ICollection<trel_UserMining> TrelUserMining { get; set; }
    }
}
