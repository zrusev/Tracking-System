namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Services.Models.Lob;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Lobs;
    using X.PagedList;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class LobsController : Controller
    {
        private readonly ILob lob;

        public LobsController(ILob lob)
        {
            this.lob = lob;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var lobs = this.lob.All();

            var onePageList = lobs.ToPagedList(pageNumber, WebConstants.MaxItemsPerPage);
            
            return View(new LobListViewModel { LobsList = onePageList });
        }

        [HttpGet]
        public IActionResult ById(string lobId)
        {
            var lob = this.lob.ById(int.Parse(lobId));

            return View(new LobViewModel { Lob = lob });
        }

        [HttpPost]
        public IActionResult ById(LobViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid lob details.");
                return View(model);
            }

            var lob = this.lob.ById(model.Lob.IdLob);
            var lobExists = lob != null;

            if (!lobExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid lob details.");
                return View(model);
            }

            var successId = this.lob.UpdateLob(new LobListModel
            {
                IdLob = model.Lob.IdLob,
                Lob = model.Lob.Lob,
                MmcpLob = model.Lob.MmcpLob,
                MmcpSegment = model.Lob.MmcpSegment,
                ProductLine1 = model.Lob.ProductLine1,
                ProductLine2 = model.Lob.ProductLine2,
                ProductLine3 = model.Lob.ProductLine3,
                SpphIdProduct = model.Lob.SpphIdProduct
            });

            TempData.AddSuccessMessage($"Lob: {model.Lob.Lob} with ID: {successId} has been updated successfully.");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddLob() => View(new AddLobViewModel());

        [HttpPost]
        public IActionResult AddLob(AddLobViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newId = this.lob.AddPLob(new LobListModel
            {
                Lob = model.Lob,
                MmcpLob = model.MmcpLob,
                MmcpSegment = model.MmcpSegment,
                ProductLine1 = model.ProductLine1,
                ProductLine2 = model.ProductLine2,
                ProductLine3 = model.ProductLine3,
                SpphIdProduct = model.SpphIdProduct
            });

            TempData.AddSuccessMessage($"Lob: {model.Lob} with ID: {newId} has been added successfully.");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveLob(int id)
        {
            if (id == 0)
            {
                TempData.AddErrorMessage($"Invalid lob id.");
                return RedirectToAction(nameof(Index));
            }

            this.lob.RemoveLob(id);

            TempData.AddSuccessMessage($"Lob with ID: {id} has been removed successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}