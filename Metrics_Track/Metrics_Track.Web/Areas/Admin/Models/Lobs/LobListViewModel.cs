﻿namespace Metrics_Track.Web.Areas.Admin.Models.Lobs
{
    using Services.Models.Lob;
    using System.Collections.Generic;

    public class LobListViewModel
    {
        public IEnumerable<LobListModel> LobsList { get; set; } = new List<LobListModel>();
    }
}
