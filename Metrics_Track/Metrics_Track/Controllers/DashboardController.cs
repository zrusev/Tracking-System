namespace Metrics_Track.Controllers
{
    using Metrics_Track.Data.Models;
    using Metrics_Track.Infrastructure.Attributes;
    using Metrics_Track.Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Services.Models.Transaction;
    using Metrics_Track.Services.Models.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Collections.Generic;
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

                return RedirectToAction(nameof(Accounts), new { id = userId });
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Accounts(string id)
        {            
            var currentUser = await this.GetUserDetailsAsync();

            if (string.IsNullOrEmpty(id) || !id.Equals(currentUser.Id))
            {
                return RedirectToAction(nameof(Index));
            }

            var modelPendings = await this.pendingList.AllAsync(currentUser.IdLogin, PendingTransactionCode, currentUser.Sandbox);

            var processMap = await this.countries.ProcessMapByIdAsync(currentUser.Id);

            var modelCountries = this.countries.CountryList(processMap);

            var modelMining = this.mining.MiningByUserId(currentUser.Id);

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

            var startDate = HttpContext.Session.Get<DateTime>("StartDate");

            if (startDate == default(DateTime))
            {
                HttpContext.Session.Set<DateTime>("StartDate", DateTime.Now);
            }

            return View(cvm);
        }

        [HttpPost]
        [AjaxOnly]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(UserActivityModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
            }

            var currentUser = await this.GetUserDetailsAsync();

            model.IdLogin = currentUser.IdLogin;
            model.ChangeStamp = DateTime.Now;
            model.Sandbox = currentUser.Sandbox;

            this.mining.AddUserActivity(model);

            return Json(new { Status = model.Type });
        }

        [HttpPost]
        [AjaxOnly]
        [Authorize]
        public async Task<IActionResult> SubmitTransaction(TransactionModel model)
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

            var currentUser = await this.GetUserDetailsAsync();

            model.IdLogin = currentUser.IdLogin;
            model.StartDate = HttpContext.Session.Get<DateTime>("StartDate");
            model.CompleteDate = DateTime.Now;
            model.Sandbox = currentUser.Sandbox;

            var identityId = this.transaction.AddTransaction(model);

            var addToPendings = (model.IdStatus == PendingIdStatusCode) ? true : false;

            var newStartDate = DateTime.Now;

            HttpContext.Session.Set<DateTime>("StartDate", newStartDate);

            return Json(new { success = true, newId = identityId, startDate = newStartDate, prem = model.Premium, pending = addToPendings });
        }

        public IActionResult StayAlive() => null;

        [Authorize]
        public async Task<IActionResult> MyDailyTransactions()
        {
            var currentUser = await this.GetUserDetailsAsync();

            var dailyTransactionsList = await this.transaction.DailyTransactions(currentUser.IdLogin);

            return View(new DailyTransactionsViewModel { DailyTransactionsList = dailyTransactionsList });
        }

        public JsonResult GetMining(int id)
        {
            var modelMining = this.mining.ById(id);
            return Json(modelMining);
        }
        private async Task<User> GetUserDetailsAsync() => await userManager.GetUserAsync(User);
    }
}