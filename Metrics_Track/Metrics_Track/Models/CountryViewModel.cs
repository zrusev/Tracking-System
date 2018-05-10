namespace Metrics_Track.Models
{
    using Metrics_Track.Services.Models.Country;
    using Metrics_Track.Services.Models.Mining;
    using Metrics_Track.Services.Models.Transaction;
    using System.Collections.Generic;
    public class CountryViewModel
    {
        public int ID_Country { get; set; }
        public List<CountryModel> CountryList { get; set; }
        public List<MiningModel> MiningList { get; set; }
        public TransactionModel Transaction { get; set; }

        public CountryViewModel()
        {
            this.CountryList = new List<CountryModel>();
            this.MiningList = new List<MiningModel>();
        }
    }
}
