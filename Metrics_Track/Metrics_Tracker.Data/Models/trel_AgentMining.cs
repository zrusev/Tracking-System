namespace Metrics_Track.Data.Models
{
    public class trel_AgentMining
    {
        public string IdAgent { get; set; }

        public User Agent { get; set; }

        public int IdMining { get; set; }

        public tbl_Mining Mining { get; set; }
    }
}
