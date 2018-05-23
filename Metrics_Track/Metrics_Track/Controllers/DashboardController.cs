namespace Metrics_Track.Controllers
{
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Metrics_Track.Data.Models;
    using System.Collections.Generic;

    public class DashboardController : Controller
    {   
        private readonly ICountry countries;
        private readonly IMining mining;
        private readonly ITransaction transaction;
        private readonly IPendingList pendingList;
        private readonly UserManager<User> userManager;

        private const int PendingIdStatusCode = 5;
        private const int PendingTransactionCode = 2;

        public DashboardController(ICountry countries, IMining mining, ITransaction transaction, IPendingList pendingList, UserManager<User> userManager)
        {
            this.countries = countries;
            this.mining = mining;
            this.transaction = transaction;
            this.pendingList = pendingList;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(User);

                var userId = userManager.GetUserId(User);

                return RedirectToAction(nameof(Accounts), new { id = userId});
            }

            return View();            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Accounts(string id)
        {
            var user = await userManager.GetUserAsync(User);
            
            var userId = userManager.GetUserId(User);

            if (string.IsNullOrEmpty(id) || !id.Equals(userId))
            {
                return RedirectToAction(nameof(Index));
            }

            var userDetails = await this.mining.UserDetailsAsync();

            var modelPendings = await this.pendingList.AllAsync(userDetails.IdLogin, PendingTransactionCode, userDetails.Sandbox);

            var processMap = await this.countries.ProcessMapByIdAsync(userId);

            var modelCountries = this.countries.CountryList(processMap);

            var modelMining = this.mining.ById(userDetails.IdLogin);

            var cvm = new CountryViewModel();

            foreach (var model in modelCountries)
            {
                cvm.CountryList.Add(model);
            }

            foreach (var model in modelMining)
            {
                cvm.MiningList.Add(model);
            }

            foreach (var model in modelPendings)
            {
                cvm.PendingList.Add(model);
            }
            
            return View(cvm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(string type, string commment)
        {
            DateTime stamp = DateTime.Now;

            var userDetails = await this.mining.UserDetailsAsync();            

            this.mining.AddUserActivity(userDetails.IdLogin, type, stamp, commment, userDetails.Sandbox);

            return Json(new { Status = type });
        }

        [HttpPost]
        [Authorize]
        public async  Task<IActionResult> SubmitTransaction(int countryId, int processId, int activityId, int lobId, int divisionId, int towerCategoryId, int towerId, 
                                                            DateTime receivedDate, DateTime startDate, DateTime completeDate, 
                                                            int statusId, string comment, string numberId, string partnerId, string contactId, double premium, string currCode,
                                                            string insuredName, string tranRequestor, int? originalId, short statusCode, short priority, string attachments, 
                                                            DateTime inceptionDate, DateTime dateReceived)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
            }

            if (statusId == PendingIdStatusCode)
            {
                statusCode = PendingTransactionCode;
            }
            else
            {
                statusCode = 1;
            }

            var userDetails = await this.mining.UserDetailsAsync();

            var identityId = this.transaction.AddTransaction(userDetails.IdLogin, countryId, processId, activityId, lobId, processId, processId, processId, 
                                                            receivedDate, startDate, DateTime.Now, 
                                                            statusId, comment, numberId, partnerId,contactId, premium, currCode, 
                                                            insuredName, tranRequestor, originalId, statusCode, priority, userDetails.Sandbox, attachments, 
                                                            inceptionDate, dateReceived);

            var addToPendings = (statusId == PendingIdStatusCode) ? true : false;

            return Json(new { success = true, newId = identityId, prem = premium, pending = addToPendings });
        }

        public JsonResult GetMining(int id)
        {
            var modelMining = this.mining.ById(id);
            return Json(modelMining);
        }
    }
}