namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.ProcessDivision;
    using Models.ProcessLob;
    using Services.Contracts;
    using System.Linq;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ProcessDivisionController : Controller
    {
        private readonly IProcessList processList;
        private readonly IDivisionList divisionList;

        public ProcessDivisionController(IProcessList processList, IDivisionList divisionList)
        {
            this.processList = processList;
            this.divisionList = divisionList;
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
        public IActionResult DivisionsMapping(int[] idProcesses)
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

            var model = new ProcessDivisionMappingViewModel
            {
                IdSelectedProcess = process.IdProcess,
                SelectedProcess = process.Process + " /" + process.ProcessMap + "/(" + process.IdProcess + ")"
            };

            var divisions = this.divisionList
                .All()
                .OrderBy(d => d.Division)
                .Select(s => new SelectListItem
                {
                    Value = s.IdDivision.ToString(),
                    Text = s.Division
                });

            model.Divisions = divisions;
            model.IdDivisions = this.divisionList.Ids(idSelection);

            return View(model);
        }

        [HttpPost]
        public IActionResult DivisionsMapping(int idProcess, int[] idDivisions)
        {
            this.processList.UpdateProcessDivisionIds(idProcess, idDivisions);

            TempData.AddSuccessMessage(WebConstants.SuccessfulMapping);

            return RedirectToAction(nameof(Index));
        }
    }
}