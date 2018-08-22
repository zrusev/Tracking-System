namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.ProcessLob;
    using Models.ProcessStatus;
    using Services.Contracts;
    using System.Linq;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ProcessStatusController : Controller
    {
        private readonly IProcessList processList;
        private readonly IStatusList statusList;

        public ProcessStatusController(IProcessList processList, IStatusList statusList)
        {
            this.processList = processList;
            this.statusList = statusList;
        }

        public IActionResult Index()
        {
            var processes = this.processList
                .All()
                .OrderBy(p => p.Process)
                .ThenBy(m => m.ProcessMap)
                .Select(c => new SelectListItem
                {
                    Value = c.IdProcess.ToString(),
                    Text = c.Process + " /" + c.ProcessMap + "/(" + c.IdProcess + ")"
                });

            var model = new ProcessLobViewModel
            {
                IdProcesses = new int[] { },
                ProcessList = processes
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult StatusesMapping(int[] idProcesses)
        {
            if (idProcesses.Length != 1)
            {
                if (idProcesses.Length > 1)
                {
                    TempData.AddErrorMessage(WebConstants.SelectSingleProcess);
                }

                return RedirectToAction(nameof(Index));
            }

            var idSelection = idProcesses[0];

            var process = this.processList.ById(idSelection);

            var model = new ProcessStatusMappingViewModel
            {
                IdSelectedProcess = process.IdProcess,
                SelectedProcess = process.Process + " /" + process.ProcessMap + "/(" + process.IdProcess + ")"
            };

            var statuses = this.statusList
                .All()
                .OrderBy(s => s.Status)
                .Select(s => new SelectListItem
                {
                    Value = s.IdStatus.ToString(),
                    Text = s.Status
                });

            model.Statuses = statuses;
            model.IdStatuses = this.statusList.Ids(idSelection);

            return View(model);
        }

        [HttpPost]
        public IActionResult StatusesMapping(int idProcess, int[] idStatuses)
        {
            this.processList.UpdateProcessStatusIds(idProcess, idStatuses);

            TempData.AddSuccessMessage(WebConstants.SuccessfulMapping);

            return RedirectToAction(nameof(Index));
        }
    }
}