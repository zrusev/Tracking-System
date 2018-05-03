namespace Metrics_Track.Services.Models
{
    using Metrics_Track.Data.Models;
    using System.Collections.Generic;
    public class CountryById
    {
        public IEnumerable<CountryDataModel> Country { get; set; }
    }
}
