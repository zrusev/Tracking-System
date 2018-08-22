namespace Metrics_Track.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin.Models;
    using System.Collections.Generic;

    public class UserListingsViewModel
    {
        public IEnumerable<AdminUserListingModel> Users { get; set; }

        public string IdTeamLead { get; set; }

        public IEnumerable<SelectListItem> TeamLeads { get; set; }
    }
}
