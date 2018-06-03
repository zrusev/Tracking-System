namespace Metrics_Track.Areas.Admin.Models
{
    using Metrics_Track.Services.Admin.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    public class UserViewModel
    {
        public AdminUserListingModel User { get; set; }
        public int[] IdCountries { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
