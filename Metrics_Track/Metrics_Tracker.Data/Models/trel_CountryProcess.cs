namespace Metrics_Track.Data.Models
{
    public class trel_CountryProcess
    {
        public int IdCp { get; set; }
        public int? IdCountry { get; set; }
        public int? IdProcess { get; set; }

        public tbl_Country IdCountryNavigation { get; set; }
        public tbl_Process IdProcessNavigation { get; set; }
    }
}
