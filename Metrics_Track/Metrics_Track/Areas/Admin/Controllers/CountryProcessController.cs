namespace Metrics_Track.Areas.Admin.Controllers
{
    using Admin.Models.CountryProcess;
    using Metrics_Track.Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class CountryProcessController : Controller
    {
        private readonly ICountry country;
        private readonly IProcessList processList;

        public CountryProcessController(ICountry country, IProcessList processList)
        {
            this.country = country;
            this.processList = processList;
        }


        public IActionResult Index(int? id)
        {
            var countries = this.country.All().Select(c => new SelectListItem
            {
                Value = c.IdCountry.ToString(),
                Text = c.Country
            });

            var idSelection = (int)(id == null ? 0 : id);

            var model = new CountryProcessViewModel
            {
                IdCountry = idSelection,
                CountryList = countries
            };

            if (idSelection == 0)
            {
                return View(model);
            }

            var processes = this.processList.All()
                .OrderBy(p => p.Process)
                .ThenBy(m => m.ProcessMap)
                .Select(s => new SelectListItem
                {
                    Value = s.IdProcess.ToString(),
                    Text =  s.Process + " /" + s.ProcessMap + "/(" + s.IdProcess + ")" 
                });

            model.Processes = processes;

            model.IdProcesses = this.processList.Ids(idSelection);

            return View(model);
        }

        [HttpPost]
        public IActionResult ModifyCountryProcess(int idCountry, int[] IdProcesses)
        {
            this.processList.UpdateIds(idCountry, IdProcesses);

            TempData.AddSuccessMessage("Mapping has been updated successfully.");

            return RedirectToAction(nameof(Index));
        }
    }
}