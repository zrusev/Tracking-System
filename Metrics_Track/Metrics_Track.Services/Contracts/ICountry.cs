namespace Metrics_Track.Services.Contracts
{
    using Models.Country;
    using Models.ProcessMap;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICountry
    {
        Task<List<ProcessMapModel>> ProcessMapByIdAsync(string id);

        List<CountryModel> CountryList(List<ProcessMapModel> processModel);

        IEnumerable<CountryModel> All();
    }
}
