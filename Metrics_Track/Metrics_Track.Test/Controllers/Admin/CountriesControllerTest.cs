namespace Metrics_Track.Test.Controllers.Admin
{
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Linq;
    using Web;
    using Web.Areas.Admin.Controllers;
    using Web.Areas.Admin.Models.Countries;

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
        public void GetAddCountry_WithValidModel_ShouldReturnView()
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
        public void PostAddCountry_WithInvalidModel_ShouldThrowException()
        {
            var service = new Mock<ICountry>();

            var controller = new CountriesController(service.Object);

            var result = controller.AddNewCountryToList(new AddCountryViewModel());
        }
    }
}