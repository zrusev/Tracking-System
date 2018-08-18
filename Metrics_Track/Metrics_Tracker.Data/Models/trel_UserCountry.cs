namespace Metrics_Track.Data.Models
{
    public class trel_UserCountry
    {
        public int IdUc { get; set; }

        public int? IdLogin { get; set; }

        public int? IdCountry { get; set; }

        public tbl_Country IdCountryNavigation { get; set; }

        public tbl_Login IdLoginNavigation { get; set; }
    }
}
