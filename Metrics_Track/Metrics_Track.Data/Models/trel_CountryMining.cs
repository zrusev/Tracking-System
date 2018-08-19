namespace Metrics_Track.Data.Models
{
    public class trel_CountryMining
    {
        public int IdCountry { get; set; }

        public tbl_Country Country { get; set; }

        public int IdMining { get; set; }

        public tbl_Mining Mining { get; set; }
    }
}
