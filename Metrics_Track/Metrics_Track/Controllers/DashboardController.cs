namespace Metrics_Track.Controllers
{
    using Metrics_Track.Data.Models;
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Services.Models.Transaction;
    using Metrics_Track.Services.Models.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class DashboardController : Controller
    {   
        private readonly ICountry countries;
        private readonly IMining mining;
        private readonly ITransaction transaction;
        private readonly IPendingList pendingList;
        private readonly UserManager<User> userManager;

        private const int CompleteTransactionIdStatusCode = 1;
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
        public async Task<IActionResult> UpdateStatus(UserActivityModel model)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
            }

            var userDetails = await this.mining.UserDetailsAsync();

            model.IdLogin = userDetails.IdLogin;
            model.ChangeStamp = DateTime.Now;
            model.Sandbox = userDetails.Sandbox;

            this.mining.AddUserActivity(model);

            return Json(new { Status = model.Type });
        }

        [HttpPost]
        [Authorize]
        public async  Task<IActionResult> SubmitTransaction(TransactionModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
            }

            if (model.IdStatus == PendingIdStatusCode)
            {
                model.StatusCode = PendingTransactionCode;
            }
            else
            {
                model.StatusCode = CompleteTransactionIdStatusCode;
            }

            var userDetails = await this.mining.UserDetailsAsync();

            model.IdLogin = userDetails.IdLogin;
            model.CompleteDate = DateTime.Now;
            model.Sandbox = userDetails.Sandbox;

            var identityId = this.transaction.AddTransaction(model);

            var addToPendings = (model.IdStatus == PendingIdStatusCode) ? true : false;

            return Json(new { success = true, newId = identityId, prem = model.Premium, pending = addToPendings });
        }

        public JsonResult GetMining(int id)
        {
            var modelMining = this.mining.ById(id);
            return Json(modelMining);
        }
    }
}