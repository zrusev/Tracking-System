namespace Metrics_Track.Areas.Admin.Controllers
{
    using Metrics_Track;
    using Metrics_Track.Data.Models;
    using Infrastructure.Extensions;
    using Metrics_Track.Services.Admin.Contracts;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var users = await this.users.AllAsync();

            var teamLeads = await this.teamLeads.AllAsync();

            foreach (var user in users)
            {
                user.TeamLeads = teamLeads;
            }

            return View(new UserListingsViewModel
            {
                Users = users,
                TeamLeads = teamLeads         
            });
        }

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

            var emailTo = string.Empty; //user.Email;
            var emailSubject = "Metrics Track account confirmation";
            var emailBody = string.Format(@"<p>Thank you for registering at Metrics Track.&nbsp;</p>
                                            <p>Your account has been revised and approved.</p>
                                            <p>Your current team leader is {0}.</p>
                                            <p><span class=""il"">You</span>&nbsp;may now log in to 
                                            <a href=""a.com"">https://metrics-track.com</a> using your e-mail and password.</p>
                                            <p><strong><sup>Metrics Track team</sup></strong></p>", teamLead.TeamLead);

            var emailConfirmation =  await emailService.SendEmailAsync(emailTo, emailSubject, emailBody);

            TempData.AddSuccessMessage($"{user.FirstName} {user.LastName} has been assigned to {teamLead.TeamLead} successfully. " + emailConfirmation);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ById(string userId)
        {
            var user = await this.users.UserByIdAsync(userId);

            var countries = this.country.All();

            var currentUser = new UserViewModel { User = user };

            return View(currentUser);
        }

        public async Task<IActionResult> UpdateUserAsync(UserViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
