namespace Metrics_Track.Areas.Admin.Controllers
{
    using Metrics_Track.Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.CountryMining;
    using System.Linq;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class CountryMiningController : Controller
    {
        private readonly ICountry country;
        private readonly IMiningList miningList;

        public CountryMiningController(ICountry country, IMiningList miningList)
        {
            this.country = country;
            this.miningList = miningList;
        }

        public IActionResult Index(int? id)
        {
            var countries = this.country
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.IdCountry.ToString(),
                    Text = c.Country
                });

            var idSelection = (int)(id == null ? 0 : id);

            var model = new CountryMiningViewModel
            {
                IdCountry = idSelection,
                CountryList = countries
            };

            if (idSelection == 0)
            {
                return View(model);
            }

            var minings = this.miningList
                .All()
                .OrderBy(s => s.State)
                .Select(s => new SelectListItem
                {
                    Value = s.IdMining.ToString(),
                    Text = s.State
                });

            model.Minings = minings;

            model.IdMinings = this.miningList.Ids(idSelection);

            return View(model);
        }

        [HttpPost]
        public IActionResult ModifyCountryMining(int idCountry, int[] idMinings)
        {
            this.miningList.UpdateIds(idCountry, idMinings);

            TempData.AddSuccessMessage(WebConstants.SuccessfulMapping);

            return RedirectToAction(nameof(Index));
        }
    }
}