namespace Metrics_Track.Controllers
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
                return RedirectToAction(nameof(Home));
            }

            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
