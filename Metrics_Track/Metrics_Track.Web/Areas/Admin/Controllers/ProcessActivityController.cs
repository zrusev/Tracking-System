namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.ProcessActivity;
    using Models.ProcessLob;
    using System.Linq;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ProcessActivityController : Controller
    {
        private readonly IProcessList processList;
        private readonly IActivityList activityList;

        public ProcessActivityController(IProcessList processList, IActivityList activityList)
        {
            this.processList = processList;
            this.activityList = activityList;
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
        public IActionResult ActivitiesMapping(int[] idProcesses)
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

            var model = new ProcessActivityMappingViewModel
            {
                IdSelectedProcess = process.IdProcess,
                SelectedProcess = process.Process + " /" + process.ProcessMap + "/(" + process.IdProcess + ")"
            };

            var activities = this.activityList
                .All()
                .OrderBy(a => a.Activity)
                .Select(s => new SelectListItem
                {
                    Value = s.IdActivity.ToString(),
                    Text = s.Activity
                });

            model.Activities = activities;
            model.IdActivities = this.activityList.Ids(idSelection);

            return View(model);
        }

        [HttpPost]
        public IActionResult ActivitiesMapping(int idProcess, int[] idActivities)
        {
            this.processList.UpdateProcessActivityIds(idProcess, idActivities);

            TempData.AddSuccessMessage(WebConstants.SuccessfulMapping);

            return RedirectToAction(nameof(Index));
        }
    }
}