namespace Metrics_Track.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Metrics_Track;
    using Metrics_Track.Data.Models;
    using Metrics_Track.Services.Admin.Contracts;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Users;
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
        public readonly IEmailService emailService;

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
            
            user.IdTeamLead = int.Parse(model.IdTeamLead);
            user.EmailConfirmed = true;

            await this.userManager.UpdateAsync(user);
            
            await this.userManager.AddToRoleAsync(user, WebConstants.AgentRole);

            var emailTo = user.Email;
            var emailSubject = "Metrics Track account confirmation";
            var emailBody = string.Format(@"<p>Thank you for registering at Metrics Track.&nbsp;</p>
                                            <p>Your account has been revised and approved.</p>
                                            <p>Your current team leader is {0}.</p>
                                            <p><span class=""il"">You</span>&nbsp;may now log in to 
                                            <a href=""https://metrics-track.azurewebsites.net/account/login"">Metrics Track</a> using your e-mail and password.</p>
                                            <p><strong><sup>Metrics Track team</sup></strong></p>", teamLead.TeamLead);

            var emailConfirmation =  await emailService.SendEmailAsync(emailTo, emailSubject, emailBody);

            TempData.AddSuccessMessage($"{user.FirstName} {user.LastName} has been assigned to {teamLead.TeamLead} successfully. " + emailConfirmation);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ById(string userId)
        {
            var user = await this.users.UserByIdAsync(userId);

            var countries = this.country.All().Select(c => new SelectListItem
            {
                Value = c.IdCountry.ToString(),
                Text = c.Country
            });

            var currentUser = new UserViewModel
            {
                User = user,
                IdCountries = user.Countries.Select(i => i.IdCountry).ToArray(),
                Countries = countries
            };

            return View(currentUser);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAsync(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await this.userManager.FindByIdAsync(model.User.Id);
            var userExists = user != null;

            if (!userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            user.FirstName = model.User.FirstName;
            user.LastName = model.User.LastName;
            user.Email = model.User.Email;
            user.UserName = model.User.Username;
            user.Sandbox = model.User.Sandbox;

            this.users.RemoveAgentToCountryTrel(user.Id);

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

            await this.userManager.UpdateAsync(user);

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

            //Remove team leader if necessary
            //this.users.RemoveTeamLeaderById(id);

            var roles = await this.userManager.GetRolesAsync(user);

            TempData.AddSuccessMessage("User removed successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}
