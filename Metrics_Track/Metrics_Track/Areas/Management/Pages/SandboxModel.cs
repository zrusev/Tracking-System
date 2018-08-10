namespace Metrics_Track.Areas.Management.Pages
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [Area(WebConstants.ManagementArea)]
    [Authorize(Roles = WebConstants.ManagerRole)]
    public class SandboxModel : PageModel
    {
    }
}
