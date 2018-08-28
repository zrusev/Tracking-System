namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Activities;
    using Services.Contracts;
    using Services.Models.Activity;
    using X.PagedList;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]

    public class ActivitiesController : Controller
    {
        private readonly IActivity activity;

        public ActivitiesController(IActivity activity)
        {
            this.activity = activity;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var activities = this.activity.All();

            var onePageList = activities.ToPagedList(pageNumber, WebConstants.MaxItemsPerPage);

            return View(new ActivityListViewModel { ActivityList = onePageList });
        }

        [HttpGet]
        public IActionResult ById(string activityId)
        {
            var activity = this.activity.ById(int.Parse(activityId));

            return View(new ActivityViewModel
            {
                Activity = activity
            });
        }

        [HttpPost]
        public IActionResult ById(ActivityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, WebConstants.InvalidActivityDetails);
                return View(model);
            }

            var activity = this.activity.ById(model.Activity.IdActivity);
            var activityExists = activity != null;

            if (!activityExists)
            {
                ModelState.AddModelError(string.Empty, WebConstants.InvalidActivityDetails);
                return View(model);
            }

            var successId = this.activity.UpdateActivity(new ActivityModel
            {
                IdActivity = model.Activity.IdActivity,
                Activity = model.Activity.Activity
            });

            TempData.AddSuccessMessage($"Activity: {model.Activity.Activity} with ID: {successId} has been updated successfully.");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddActivity() => View(new AddActivityViewModel());

        [HttpPost]
        public IActionResult AddActivity(AddActivityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newId = this.activity.AddActivity(new ActivityModel
            {
                Activity = model.Activity
            });

            TempData.AddSuccessMessage($"Activity: {model.Activity} with ID: {newId} has been added successfully.");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveActivity(int id)
        {
            if (id == 0)
            {
                TempData.AddErrorMessage(WebConstants.InvalidActivityId);
                return RedirectToAction(nameof(Index));
            }

            this.activity.RemoveActivity(id);

            TempData.AddSuccessMessage($"Activity with ID: {id} has been removed successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}