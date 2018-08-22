namespace Metrics_Track.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Users;
    using Services.Admin.Contracts;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using X.PagedList;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class UsersController : Controller
    {
        private readonly IAdminUser users;
        private readonly ITeamLead teamLeads;
        private readonly ICountry country;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IEmailService emailService;

        public UsersController(
            IAdminUser users,
            ITeamLead teamLeads,
            ICountry country,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            IEmailService emailService)
        {
            this.users = users;
            this.teamLeads = teamLeads;
            this.country = country;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.emailService = emailService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;

            var users = await this.users.AllAsync();

            var onePageList = users.ToPagedList(pageNumber, 25);

            var teamLeads = await this.teamLeads.AllAsync();

            foreach (var user in onePageList)
            {
                user.TeamLeads = teamLeads;
            }

            return View(new UserListingsViewModel
            {
                Users = onePageList,
                TeamLeads = teamLeads         
            });
        }

        [HttpPost]
        public async Task<IActionResult> AssignToTeamLead(AddUserToTeamLeadFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            var teamLead = await this.teamLeads.FindTeamLeadAsync(int.Parse(model.IdTeamLead));
            var teamLeadExists = teamLead != null;

            var roleExists = await this.roleManager.RoleExistsAsync(WebConstants.AgentRole);

            if (!userExists || !teamLeadExists || !roleExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            user.IdTeamLead = int.Parse(model.IdTeamLead);
            user.EmailConfirmed = true;

            await this.userManager.UpdateAsync(user);
            
            await this.userManager.AddToRoleAsync(user, WebConstants.AgentRole);

            var emailUrl = string.Format("{0}://{1}{2}/account/login", Request.Scheme, Request.Host, Request.PathBase);
            var emailTo = user.Email;
            var emailSubject = WebConstants.EmailSubject;
            var emailBody = string.Format(WebConstants.EmailBody,
                                          teamLead.TeamLead,
                                          emailUrl);

            var emailConfirmation = await emailService.SendEmailAsync(emailTo, emailSubject, emailBody);

            TempData.AddSuccessMessage($"{user.FirstName} {user.LastName} has been assigned to {teamLead.TeamLead} successfully. " + emailConfirmation);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ById(string userId)
        {
            var appUser = await this.userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                TempData.AddErrorMessage("User not found. Invalid ID.");

                return RedirectToAction(nameof(Index));
            }

            var countries = this.country
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.IdCountry.ToString(),
                    Text = c.Country
                });

            var user = await this.users.UserByIdAsync(userId);

            return View(new UserViewModel
            {
                User = user,
                IdCountries = user.Countries.Select(i => i.IdCountry).ToArray(),
                Countries = countries,
                IsManager = await this.userManager.IsInRoleAsync(appUser, WebConstants.ManagerRole),
                IsAdmin = await this.userManager.IsInRoleAsync(appUser, WebConstants.AdministratorRole)
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAsync(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage("Invalid model details.");

                return RedirectToAction(nameof(Index));
            }

            var user = await this.userManager.FindByIdAsync(model.User.Id);

            var userExists = user != null;

            if (!userExists)
            {
                TempData.AddErrorMessage("Invalid identity details.");

                return View(model);
            }

            var targetUserId = user.Id;
            var currentUserId = HttpContext.User.Claims.Select(s => s.Value).FirstOrDefault();

            if (targetUserId.Equals(currentUserId))
            {
                TempData.AddErrorMessage("Self modifications are not allowed.");
                return RedirectToAction(nameof(Index));
            }

            user.FirstName = model.User.FirstName;
            user.LastName = model.User.LastName;
            user.Email = model.User.Email;
            user.UserName = model.User.Username;
            user.Sandbox = model.User.Sandbox;            

            this.users.RemoveAgentToCountryTrel(user.Id);

            if (model.IdCountries != null)
            {
                var countryList = new List<trel_AgentCountry>();

                foreach (var id in model.IdCountries)
                {
                    var trel = new trel_AgentCountry
                    {
                        IdAgent = user.Id,
                        IdCountry = id
                    };

                    countryList.Add(trel);
                }

                user.Countries = countryList;
            }

            await this.userManager.UpdateAsync(user);

            await SetRolesAsync(user, model.IsManager, WebConstants.ManagerRole);

            await SetRolesAsync(user, model.IsAdmin, WebConstants.AdministratorRole);

            TempData.AddSuccessMessage($"{user.FirstName} {user.LastName} has been updated successfully.");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemoveUser(UserViewModel model)
        {
            ViewData["id"] = model.User.Id;
            ViewData["user"] = model.User.FirstName + " " + model.User.LastName;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserById(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            this.users.RemoveTeamLeaderById(id);

            await this.userManager.RemoveFromRoleAsync(user, WebConstants.AgentRole);

            TempData.AddSuccessMessage("User removed successfully.");
            return RedirectToAction(nameof(Index));
        }

        private async Task SetRolesAsync(User user, bool modelRole, string targetRole)
        {
            var currentManagerRole = await this.userManager.IsInRoleAsync(user, targetRole);

            if (modelRole == true && currentManagerRole == false)
            {
                await this.userManager.AddToRoleAsync(user, targetRole);

                if (targetRole.Equals(WebConstants.ManagerRole))
                {
                    this.users.AddToManagersList(user);
                }
            }

            if (modelRole == false && currentManagerRole == true)
            {
                await this.userManager.RemoveFromRoleAsync(user, targetRole);

                if (targetRole.Equals(WebConstants.ManagerRole))
                {
                    this.users.RemoveFromManagersList(user);
                }
            }
        }
    }
}
