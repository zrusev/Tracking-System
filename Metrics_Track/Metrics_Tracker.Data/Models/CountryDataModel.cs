namespace Metrics_Track.Data.Models
{
    using System.Collections.Generic;
    public class CountryDataModel
    {
        public int ID_Country { get; set; }

        public string Country { get; set; }

        public List<ProcessDataModel> ProcessList { get; set; }

        public CountryDataModel()
        {
            this.ProcessList = new List<ProcessDataModel>();
        }
    }
}
