namespace Metrics_Track.Areas.Admin.Models.Countries
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CountryViewModel
    {
        public int[] IdCountries { get; set; }

        [Display(Name="All Countries")]
        public IEnumerable<SelectListItem> CountryList { get; set; } = new List<SelectListItem>();
    }
}
