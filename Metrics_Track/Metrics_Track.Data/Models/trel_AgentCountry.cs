namespace Metrics_Track.Data.Models
{
    public class trel_AgentCountry
    {
        public string IdAgent { get; set; }

        public User Agent { get; set; }

        public int IdCountry { get; set; }

        public tbl_Country Country { get; set; }
    }
}
