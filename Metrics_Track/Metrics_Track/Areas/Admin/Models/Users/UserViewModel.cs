namespace Metrics_Track.Areas.Admin.Models.Users
{
    using Metrics_Track.Services.Admin.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    public class UserViewModel
    {
        public AdminUserListingModel User { get; set; }

        public int[] IdCountries { get; set; }

        public bool IsManager { get; set; }

        public bool IsAdmin { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
