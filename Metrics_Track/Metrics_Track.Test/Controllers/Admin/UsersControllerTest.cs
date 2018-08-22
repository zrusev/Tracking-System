namespace Metrics_Track.Test.Controllers.Admin
{
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Moq;
    using System.Threading.Tasks;
    using Web.Areas.Admin.Controllers;
    using Web.Areas.Admin.Models.Users;

    [TestClass]
    public class UsersControllerTest
    {
        private ITempDataDictionary tempData;

        [TestMethod]
        public async Task GetById_ShouldReturnRedirectToActionResult_WithInvalidUserId()
        {
            var testId = "a1-b2-c3";

            var userManager = UserManagerMock.New;

            var controller = new UsersController(null, null, null, null, userManager.Object, null)
            {
                TempData = this.tempData
            };

            var result = await controller.ById(testId);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public async Task PostAssignToTeamLead_ShouldRedirectToAction_WithInvalidModelDetails()
        {
            var teamLeads = new Mock<ITeamLead>();

            var roleManager = RoleManagerMock.New;

            var userManager = UserManagerMock.New;

            var controller = new UsersController(null, teamLeads.Object, null, roleManager.Object, userManager.Object, null)
            {
                TempData = this.tempData
            };

            var result = await controller.AssignToTeamLead(new AddUserToTeamLeadFormModel() { UserId  = "1", IdTeamLead = "1" });

            Assert.IsFalse(controller.ModelState.IsValid);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.tempData = new Mock<ITempDataDictionary>().Object;
        }
    }
}
