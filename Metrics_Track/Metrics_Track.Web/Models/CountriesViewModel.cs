namespace Metrics_Track.Web.Models
{
    using Services.Models.Country;
    using Services.Models.Mining;
    using Services.Models.Transaction;
    using System.Collections.Generic;

    public class CountriesViewModel
    {
        public CountriesViewModel()
        {
            this.CountryList = new List<CountryModel>();
            this.MiningList = new List<MiningModel>();
            this.PendingList = new List<PendingListModel>();
            this.PreviousTransaction = new List<PreviousTransactionModel>();
        }

        public int ID_Country { get; set; }

        public List<CountryModel> CountryList { get; set; }

        public List<MiningModel> MiningList { get; set; }

        public TransactionModel Transaction { get; set; }

        public List<PendingListModel> PendingList { get; set; }

        public IEnumerable<PreviousTransactionModel> PreviousTransaction { get; set; }
    }
}
