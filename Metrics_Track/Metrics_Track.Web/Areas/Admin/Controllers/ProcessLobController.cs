namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.ProcessLob;
    using System.Linq;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ProcessLobController : Controller
    {
        private readonly IProcessList processList;
        private readonly ILobList lobList;

        public ProcessLobController(IProcessList processList, ILobList lobList)
        {
            this.processList = processList;
            this.lobList = lobList;
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
        public IActionResult LobsMapping(int[] idProcesses)
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

            var model = new ProcessLobMappingViewModel
            {
                IdSelectedProcess = process.IdProcess,
                SelectedProcess = process.Process + " /" + process.ProcessMap + "/(" + process.IdProcess + ")"
            };

            var lobs = this.lobList
                .All()
                .OrderBy(l => l.Lob)
                .Select(s => new SelectListItem
                {
                    Value = s.ID_Lob.ToString(),
                    Text = s.Lob
                });

            model.Lobs = lobs;
            model.IdLobs = this.lobList.Ids(idSelection);

            return View(model);
        }

        [HttpPost]
        public IActionResult LobsMapping(int idProcess, int[] idLobs)
        {
            this.processList.UpdateProcessLobIds(idProcess, idLobs);

            TempData.AddSuccessMessage(WebConstants.SuccessfulMapping);

            return RedirectToAction(nameof(Index));
        }
    }
}