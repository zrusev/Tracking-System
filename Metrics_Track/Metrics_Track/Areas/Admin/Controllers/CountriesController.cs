namespace Metrics_Track.Areas.Admin.Controllers
{
    using Metrics_Track.Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Services.Models.Country;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Countries;
    using System.Linq;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class CountriesController : Controller
    {
        private readonly ICountry country;

        public CountriesController(ICountry country)
        {
            this.country = country;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var countries = this.country.All().Select(c => new SelectListItem
            {
                Value = c.ID_Country.ToString(),
                Text = c.Country
            });

            return View(new CountryViewModel { CountryList = countries });
        }

        [HttpGet]
        public IActionResult RemoveCountries()
        {
            TempData.AddErrorMessage("Removing countries is not allowed.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddCountry()
            => View(new AddCountryVewModel());

        [HttpPost]
        public IActionResult AddNewCountryToList(AddCountryVewModel model)
        {
            var successId = this.country.AddNewCountry(new CountryModel
            {
                Country = model.Country,
                RefSite = model.RefSite,
                SpphIdCountry = model.SpphIdCountry
            });

            TempData.AddSuccessMessage($"Successfully added new country with id: {successId}.");
            return RedirectToAction(nameof(Index));
        }
    }
}