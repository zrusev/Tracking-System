namespace Metrics_Track.Controllers
{
    using Metrics_Track.Models;
    using Metrics_Track.Services.Services;
    using Microsoft.AspNetCore.Mvc;
    public class CountriesController : Controller
    {   
        private readonly ICountry countries;
        private readonly IMining mining;

        public CountriesController(ICountry countries, IMining mining)
        {
            this.countries = countries;
            this.mining = mining;
        }

        [Route("Countries/ById/{id}")]
        public IActionResult ById(int id)
        {
            var modelCountries = this.countries.ById(id);
            var modelMining = this.mining.ById(id);

            var cvm = new CountryViewModel();

            foreach (var model in modelCountries)
            {
                cvm.CountryList.Add(model);
            }

            foreach (var model in modelMining)
            {
                cvm.MiningList.Add(model);
            }

            return View(cvm);
        }

    }
}
