namespace Metrics_Track.Web.Controllers
{
    using Infrastructure.Attributes;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        [ViewLayout("_CleanLayout")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Workspace));
            }

            return View();
        }

        public IActionResult Workspace() => View();

        public IActionResult Error() 
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}
