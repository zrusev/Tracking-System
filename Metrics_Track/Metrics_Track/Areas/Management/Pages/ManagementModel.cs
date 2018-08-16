namespace Metrics_Track.Web.Areas.Management.Pages
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [Area(WebConstants.ManagementArea)]
    [Authorize(Roles = WebConstants.ManagerRole)]
    public class ManagementModel : PageModel
    {
    }
}
