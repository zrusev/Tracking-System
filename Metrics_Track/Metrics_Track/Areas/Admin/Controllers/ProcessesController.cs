namespace Metrics_Track.Areas.Admin.Controllers
{
    using Metrics_Track.Areas.Admin.Models.Processes;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ProcessesController : Controller
    {
        private readonly IProcessList processList;

        public ProcessesController(IProcessList processList)
        {
            this.processList = processList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = this.processList.All();

            return View(new ProcessListViewModel { ProcessList = list});
        }

        [HttpGet]
        public IActionResult ById(string processId)
        {
            //To be implemented
            return RedirectToAction(nameof(Index));
        }

    }
}