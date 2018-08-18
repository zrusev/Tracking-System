namespace Metrics_Track.Test.Controllers.Admin
{
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Web;
    using Metrics_Track.Web.Areas.Admin.Controllers;
    using Metrics_Track.Web.Areas.Admin.Models.Countries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Linq;

    [TestClass]
    public class CountriesControllerTest
    {
        [TestMethod]
        public void CountriesController_ShouldBeInAdminArea()
        {
            var controller = typeof(CountriesController);

            var areaAttribute = controller
                    .GetCustomAttributes(true)
                    .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                    as AreaAttribute;

            Assert.IsNotNull(areaAttribute);

            Assert.AreEqual(areaAttribute.RouteValue, WebConstants.AdminArea);
        }

        [TestMethod]
        public void CountriesController_ShouldBeOnlyForAdminUsers()
        {
            var controller = typeof(CountriesController);

            var areaAttribute = controller
                    .GetCustomAttributes(true)
                    .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute)) as AuthorizeAttribute;

            Assert.IsNotNull(areaAttribute);

            Assert.AreEqual(areaAttribute.Roles, WebConstants.AdministratorRole);
        }

        [TestMethod]
        public void GetAddCountry_ShouldReturnViewWithValidModel()
        {            
            var service = new Mock<ICountry>();

            var controller = new CountriesController(service.Object);

            var result = controller.AddCountry();

            Assert.IsInstanceOfType(result, typeof(IActionResult));
            
            ViewResult model = result as ViewResult;

            Assert.IsInstanceOfType(model.Model, typeof(AddCountryViewModel));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PostAddCountry_ShouldThrowException()
        {
            var service = new Mock<ICountry>();

            var controller = new CountriesController(service.Object);

            var result = controller.AddNewCountryToList(new AddCountryViewModel());
        }
    }
}