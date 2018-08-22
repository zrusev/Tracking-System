namespace Metrics_Track.Services.Admin.Models
{
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class CountryProcessModel : IMapFrom<trel_CountryProcess>
    {
        public IEnumerable<trel_CountryProcess> Trel { get; set; } = new List<trel_CountryProcess>();
    }
}