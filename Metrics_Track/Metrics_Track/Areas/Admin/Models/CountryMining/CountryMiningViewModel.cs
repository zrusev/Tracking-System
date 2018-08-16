namespace Metrics_Track.Web.Areas.Admin.Models.CountryMining
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class CountryMiningViewModel
    {
        public int IdCountry { get; set; }

        public IEnumerable<SelectListItem> CountryList { get; set; } = new List<SelectListItem>();

        public int[] IdMinings { get; set; }

        public IEnumerable<SelectListItem> Minings { get; set; }
    }
}
