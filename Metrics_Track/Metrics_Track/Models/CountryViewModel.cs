namespace Metrics_Track.Models
{
    using Metrics_Track.Data.Models;
    using System.Collections.Generic;
    public class CountryViewModel
    {
        public int ID_Country { get; set; }
        public List<CountryDataModel> CountryList { get; set; }

        public List<MiningDataModel> MiningList { get; set; }

        public CountryViewModel()
        {
            this.CountryList = new List<CountryDataModel>();
            this.MiningList = new List<MiningDataModel>();
        }
    }
}
