namespace Metrics_Track.Controllers
{
    using Metrics_Track.Services.Services;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    public class CountriesController : Controller
    {   
        private readonly ICountry countries;
        private readonly IMining mining;
        private readonly ITransaction transaction;

        public CountriesController(ICountry countries, IMining mining, ITransaction transaction)
        {
            this.countries = countries;
            this.mining = mining;
            this.transaction = transaction;
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

        public IActionResult UpdateStatus(string type, string comment)
        {
            int id = 145;
            string activityType = type;
            DateTime stamp = DateTime.Now;
            string activityCommment = comment;
            short sandbox = 1;
            string version = null;

            this.mining.AddUserActivity(id, activityType, stamp, activityCommment, sandbox, version);

            return Json(new { Status = activityType });
        }

        public IActionResult SubmitTransaction(int processId, int activityId, int lobId,
                                   DateTime receivedDate, DateTime startDate, DateTime completeDate, int statusId, string comment,
                                   string numberId, string partnerId, string contactId, double premium, string currCode,
                                   string insuredName, string tranRequestor, int originalId, short statusCode, short priority, string attachments,
                                   DateTime inceptionDate, DateTime dateReceived)
        {
            var identityId = this.transaction.AddTransaction(145, 15, processId, activityId, lobId, processId, processId, processId, receivedDate, startDate,
                                                            DateTime.Now, 1, comment, numberId, string.Empty, string.Empty, premium, "EUR",
                                                            string.Empty, string.Empty, 0, 1, 0, string.Empty, inceptionDate, dateReceived);

            return Json(new { Status = "Transaction has been uploaded successfully!", newId = identityId });
        }

        public JsonResult GetMining(int id)
        {
            var modelMining = this.mining.ById(id);
            return Json(modelMining);
        }
    }
}