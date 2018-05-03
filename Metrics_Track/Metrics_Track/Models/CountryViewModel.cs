namespace Metrics_Track.Models
{
    using Metrics_Track.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    public class CountryViewModel
    {
        public int ID_Country { get; set; }
        public List<CountryDataModel> CountryList { get; set; }

        public List<MiningDataModel> MiningList { get; set; }

        public IEnumerable<SelectListItem> CountryEnum
        {
            get
            {
                return new SelectList(CountryList, "ID", "CountryName");
            }
        }

        public CountryViewModel()
        {
            this.CountryList = new List<CountryDataModel>();
            this.MiningList = new List<MiningDataModel>();
        }
    }
}
