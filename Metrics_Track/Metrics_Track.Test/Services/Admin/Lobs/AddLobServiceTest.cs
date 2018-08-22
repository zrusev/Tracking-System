namespace Metrics_Track.Test.Services.Admin.Lobs
{
    using AutoMapper;
    using Common.Validation;
    using Data.Models;
    using Metrics_Track.Services.Implementations;
    using Metrics_Track.Services.Models.Lob;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using System;
    using System.Linq;

    [TestClass]
    public class AddLobServiceTest
    {
        private const string lobName = "Lob5";
        private const string lobMmcpLob = "MmcpLob";

        private TrackerDbContext db;
        private IMapper mapper;
        private Lob service;

        [TestMethod]
        public void AddLob_WithProperLob_ShouldAddCorrectly()
        {

            var lobModel = new LobListModel()
            {
                IdLob = 5,
                Lob = lobName,
                MmcpLob = lobMmcpLob,
                MmcpSegment = "MmcpSegment",
                ProductLine1 = "ProductLine1",
                ProductLine2 = "ProductLine2",
                ProductLine3 = "ProductLine3",
                SpphIdProduct = 1234
            };

            this.service.AddLob(lobModel);

            Assert.AreEqual(1, this.db.TblLob.Count());
            Assert.AreEqual(lobName, lobModel.Lob);
            Assert.AreEqual(lobMmcpLob, lobModel.MmcpLob);
        }

        [TestMethod]
        public void AddLob_WithNullLob_ShouldThrowException()
        {
            LobListModel lobModel = null;

            Func<object> addLob = () => this.service.AddLob(lobModel);

            var exception = Assert.ThrowsException<ArgumentException>(addLob);

            Assert.AreEqual(ValidationConstants.LobDefinedMessage, exception.Message);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.db = MockDbContext.GetContext();
            this.mapper = MockAutoMapper.GetMapper();
            this.service = new Lob(this.db);
        }
    }
}