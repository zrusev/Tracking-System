namespace Metrics_Track.Areas.Admin.Controllers
{
    using Metrics_Track;
    using Metrics_Track.Data.Models;
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
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(
            IAdminUser users,
            ITeamLead teamLeads,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.users = users;
            this.teamLeads = teamLeads;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.users.AllAsync();

            var teamLeads = await this.teamLeads.AllAsync();

            return View(new UserListingsViewModel
            {
                Users = users,
                TeamLeads = teamLeads         
            });
        }

        public async Task<IActionResult> AssignToTeamLead(AddUserToTeamLeadFormModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            var teamLead = await this.teamLeads.FindTeamLeadAsync(int.Parse(model.TeamLead));
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

            user.IdTeamLead = int.Parse(model.TeamLead);            
            await this.userManager.UpdateAsync(user);
            
            await this.userManager.AddToRoleAsync(user, WebConstants.AgentRole);

            TempData["SuccessMessage"] = $"User {user.Email} successfully assigned to {teamLead.TeamLead}.";
            return RedirectToAction(nameof(Index));
        }
    }
}
