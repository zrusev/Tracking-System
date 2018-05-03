namespace Metrics_Track.Controllers
{
    using Metrics_Track.Models;
    using Metrics_Track.Services.Services;
    using Microsoft.AspNetCore.Mvc;
    public class CountriesController : Controller
    {   
        private readonly ICountry countries;
        public CountriesController(ICountry countries)
        {
            this.countries = countries;
        }

        [Route("Countries/ById/{id}")]
        public IActionResult ById(int id)
        {
            var modelCountries = this.countries.ById(id);
            var cvm = new CountryViewModel();

            foreach (var model in modelCountries)
            {
                cvm.CountryList.Add(model);
            }

            return View(cvm);
        }

    }
}
