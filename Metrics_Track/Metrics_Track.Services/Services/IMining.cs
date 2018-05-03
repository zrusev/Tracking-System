namespace Metrics_Track.Services.Services
{
    using Metrics_Track.Data.Models;
    using System.Collections.Generic;
    public interface IMining
    {
        IEnumerable<tbl_Mining> ById(int id);
    }
}
