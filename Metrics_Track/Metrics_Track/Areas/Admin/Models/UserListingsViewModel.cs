namespace Metrics_Track.Areas.Admin.Models
{
    using Metrics_Track.Services.Admin.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    public class UserListingsViewModel
    {
        public IEnumerable<AdminUserListingModel> Users { get; set; }

        public IEnumerable<SelectListItem> TeamLeads { get; set; }
    }
}
