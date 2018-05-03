namespace Metrics_Track.Controllers
{
    using Metrics_Track.Services.Services;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    public class MiningsController : Controller
    {
        private readonly IMining minings;

        public MiningsController(IMining minings)
        {
            this.minings = minings;
        }

        //[Route("Minings/ById/{id}")]
        //public IActionResult ById(int id)
        //{
        //    var minings = this.minings.ById(id);

        //    return View(new MiningById
        //    {
        //        Minings = minings
        //    });
        //}
    }
}
