namespace Metrics_Track.Services.Services
{
    using Metrics_Track.Data.Models;
    using System.Collections.Generic;
    public interface ICountry
    {
        IEnumerable<CountryDataModel> ById(int id);
    }
}
