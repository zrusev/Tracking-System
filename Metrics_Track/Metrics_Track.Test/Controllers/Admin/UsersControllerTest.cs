namespace Metrics_Track.Test.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Threading.Tasks;
    using Web.Areas.Admin.Controllers;

    [TestClass]
    public class UsersControllerTest
    {
        private ITempDataDictionary tempData;

        [TestMethod]
        public async Task ByIdShouldReturnRedirectToActionResultWithInvalidUserId()
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

        [TestInitialize]
        public void InitializeTests()
        {
            this.tempData = new Mock<ITempDataDictionary>().Object;
        }
    }
}
