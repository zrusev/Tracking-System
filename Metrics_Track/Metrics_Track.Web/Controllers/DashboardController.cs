namespace Metrics_Track.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Attributes;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;
    using Services.Models.Transaction;
    using Services.Models.User;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = WebConstants.AgentRole)]
    public class DashboardController : Controller
    {
        private const int PendingIdStatusCode = 5;
        private const int PendingTransactionCode = 2;
        private const short VoidStatusCode = 3;

        private readonly ICountry countries;
        private readonly IMining mining;
        private readonly ITransaction transaction;
        private readonly IPendingList pendingList;
        private readonly UserManager<User> userManager;        

        public DashboardController(ICountry countries, IMining mining, ITransaction transaction, IPendingList pendingList, UserManager<User> userManager)
        {
            this.countries = countries;
            this.mining = mining;
            this.transaction = transaction;
            this.pendingList = pendingList;
            this.userManager = userManager;
        }

        [HttpGet]
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

            var cvm = new CountriesViewModel();

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

            var previousTransactionId = HttpContext.Session.Get<int>("PreviousTransactionId");

            if (previousTransactionId != default(int))
            {
                cvm.PreviousTransaction = this.transaction.PreviousTransaction(previousTransactionId);
            }
            
            if (HttpContext.Session.Get<DateTime>("StartDate") == default(DateTime))
            {
                HttpContext.Session.Set<DateTime>("StartDate", DateTime.Now);
            }

            return View(cvm);
        }

        [HttpPost]
        [AjaxOnly]
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
        public async Task<IActionResult> SubmitTransaction(TransactionModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
            }

            var exists = this.transaction.Exists(model);

            if (!exists)
            {
                this.ModelState.AddModelError("model", WebConstants.InvalidTransactionMapping);
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() });
            }

            var currentUser = await this.GetUserDetailsAsync();

            model.IdLogin = currentUser.IdLogin;
            model.StartDate = HttpContext.Session.Get<DateTime>("StartDate");
            model.CompleteDate = DateTime.Now;
            model.Sandbox = currentUser.Sandbox;

            var identityId = this.transaction.AddTransaction(model);

            var newStartDate = DateTime.Now;

            HttpContext.Session.Set<int>("PreviousTransactionId", identityId);

            HttpContext.Session.Set<DateTime>("StartDate", newStartDate);

            var addToPendings = (model.IdStatus == PendingIdStatusCode) ? true : false;

            return Json(new { success = true, newId = identityId, startDate = newStartDate, prem = model.Premium, pending = addToPendings });
        }

        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> ReturnTransaction(int transactionId)
        {
            if (transactionId == 0)
            {
                return Json(new { success = false, errors = WebConstants.InvalidTransactionId });
            }
            
            var transaction = this.transaction.ReturnedTransaction(transactionId);

            if (transaction == null)
            {
                return Json(new { success = false, errors = WebConstants.MissingTransaction });            
            }

            var currentUser = await this.GetUserDetailsAsync();
            if (transaction.IdLogin != currentUser.IdLogin || transaction.Sandbox != currentUser.Sandbox)
            {
                return Json(new { success = false, errors = WebConstants.WrongAssignment });
            }
            
            this.transaction.UpdateStatusCode(transactionId, VoidStatusCode);

            return Json(new { success = true, transaction });
        }

        [HttpGet]
        public async Task<IActionResult> MyDailyTransactions()
        {
            var currentUser = await this.GetUserDetailsAsync();

            var dailyTransactionsList = await this.transaction.DailyTransactions(currentUser.IdLogin);

            return View(new DailyTransactionsViewModel { DailyTransactionsList = dailyTransactionsList });
        }

        public IActionResult StayAlive() => null;

        public JsonResult GetMining(int id) => Json(this.mining.ById(id));
        
        private async Task<User> GetUserDetailsAsync() => await userManager.GetUserAsync(User);
    }
}