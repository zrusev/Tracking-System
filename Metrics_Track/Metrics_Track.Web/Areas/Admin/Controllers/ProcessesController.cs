namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Processes;
    using Services.Contracts;
    using Services.Models.Process;
    using X.PagedList;

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
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var list = this.processList.All();

            var onePageList = list.ToPagedList(pageNumber, WebConstants.MaxItemsPerPage);

            return View(new ProcessListViewModel { ProcessList = onePageList });
        }

        [HttpGet]
        public IActionResult ById(string processId)
        {
            var process = this.processList.ById(int.Parse(processId));

            return View(new ProcessViewModel { Process = process });
        }

        [HttpPost]
        public IActionResult ById(ProcessViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, WebConstants.InvalidProcessDetails);
                return View(model);
            }

            var process = this.processList.ById(model.Process.IdProcess);
            var processExists = process != null;

            if (!processExists)
            {
                ModelState.AddModelError(string.Empty, WebConstants.InvalidProcessDetails);
                return View(model);
            }

            var successId = this.processList.UpdateProcess(new ProcessListModel
                    {
                        IdProcess = model.Process.IdProcess,
                        Process = model.Process.Process,
                        FunctionName = model.Process.FunctionName,
                        ProcessMap = model.Process.ProcessMap,
                        Mnc = model.Process.Mnc,
                        SlaType = model.Process.SlaType,
                        SlaTarget = model.Process.SlaTarget,
                        Level2Taxonomy = model.Process.Level2Taxonomy,
                        Level3Taxonomy = model.Process.Level3Taxonomy,
                        Pid = model.Process.Pid,
                        NiceQueue = model.Process.NiceQueue,
                        Group = model.Process.Group,
                        SpphIdProcess = model.Process.SpphIdProcess
                    });

            TempData.AddSuccessMessage($"Process: {model.Process.Process} with ID: {successId} has been updated successfully.");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddProcess() => View(new AddProcessViewModel());

        [HttpPost]
        public IActionResult AddProcess(AddProcessViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newId = this.processList.AddProcess(new ProcessListModel
            {
                Process = model.Process,
                FunctionName = model.FunctionName,
                ProcessMap = model.ProcessMap,
                Mnc = model.Mnc,
                SlaType = model.SlaType,
                SlaTarget = model.SlaTarget,
                Level2Taxonomy = model.Level2Taxonomy,
                Level3Taxonomy = model.Level3Taxonomy,
                Pid = model.Pid,
                NiceQueue = model.NiceQueue,
                Group = model.Group,
                SpphIdProcess = model.SpphIdProcess
            });

            TempData.AddSuccessMessage($"Process: {model.Process} with ID: {newId} has been added successfully.");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveProcess(int id)
        {
            if (id == 0)
            {
                TempData.AddErrorMessage(WebConstants.InvalidProcessId);
                return RedirectToAction(nameof(Index));
            }

            this.processList.RemoveProcess(id);

            TempData.AddSuccessMessage($"Process with ID: {id} has been removed successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}