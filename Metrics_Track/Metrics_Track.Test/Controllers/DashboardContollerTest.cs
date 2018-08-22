namespace Metrics_Track.Test.Controllers
{
    using Data.Models;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Web.Controllers;

    [TestClass]
    public class DashboardContollerTest
    {
        private const string FirstUserId = "1";
        private const string FirstUserUsername = "First";
        private const string SecondUserId = "2";
        private const string SecondUserUsername = "Second";

        [TestMethod]
        public async Task DashboardContoller_ShoudReturnRedirectToActionWhenIsAuthenticated()
        {
            var usr = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.NameIdentifier, "1"),
                 new Claim(ClaimTypes.Name, string.Empty)
            }));

            var userManager = this.GetUserManagerMock();
            var controller = new DashboardController(new Mock<ICountry>().Object,
                                                     new Mock<IMining>().Object,
                                                     new Mock<ITransaction>().Object,
                                                     new Mock<IPendingList>().Object,
                                                     userManager.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = usr }
            };

            ViewResult result = await controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }

        private Mock<UserManager<User>> GetUserManagerMock()
        {
            var userManager = UserManagerMock.New;
            userManager
                .Setup(u => u.GetUsersInRoleAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<User>
                {
                    new User { Id = FirstUserId, UserName = FirstUserUsername },
                    new User { Id = SecondUserId, UserName = SecondUserUsername }
                });

            return userManager;
        }
    }

    public class UserManagerMock
    {
        public static Mock<UserManager<User>> New
            => new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
    }

}
