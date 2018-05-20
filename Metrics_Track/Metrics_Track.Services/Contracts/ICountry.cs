namespace Metrics_Track.Services.Contracts
{
    using Models.Country;
    using System.Collections.Generic;
    public interface ICountry
    {
        IEnumerable<CountryModel> ById(string id);

        IEnumerable<CountryModel> All();
    }
}
