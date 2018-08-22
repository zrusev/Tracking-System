namespace Metrics_Track.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin.Models;
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
