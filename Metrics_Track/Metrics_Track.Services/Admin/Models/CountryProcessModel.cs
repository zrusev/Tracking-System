namespace Metrics_Track.Services.Admin.Models
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;
    using System.Collections.Generic;
    public class CountryProcessModel : IMapFrom<trel_CountryProcess>
    {
        IEnumerable<trel_CountryProcess> Trel = new List<trel_CountryProcess>();
    }
}
