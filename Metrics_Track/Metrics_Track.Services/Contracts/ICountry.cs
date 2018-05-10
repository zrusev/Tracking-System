namespace Metrics_Track.Services.Contracts
{
    using Models.Country;
    using System.Collections.Generic;
    public interface ICountry
    {
        IEnumerable<CountryModel> ById(int id);
    }
}
