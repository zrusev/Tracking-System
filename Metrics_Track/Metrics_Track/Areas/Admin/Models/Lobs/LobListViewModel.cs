namespace Metrics_Track.Areas.Admin.Models.Lobs
{
    using Metrics_Track.Services.Models.Lob;
    using System.Collections.Generic;

    public class LobListViewModel
    {
        public IEnumerable<LobListModel> LobsList { get; set; } = new List<LobListModel>();
    }
}
