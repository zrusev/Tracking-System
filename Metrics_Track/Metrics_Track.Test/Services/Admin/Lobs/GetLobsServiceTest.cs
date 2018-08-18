namespace Metrics_Track.Test.Services.Admin.Lobs
{
    using AutoMapper;
    using Metrics_Track.Data.Models;
    using Metrics_Track.Services.Implementations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using System.Linq;

    [TestClass]
    public class GetLobsServiceTest
    {
        private TrackerDbContext db;
        private IMapper mapper;

        [TestMethod]
        public void GetLobs_WithFewLobs_ShouldReturnAll()
        {
            this.db.TblLob.Add(new tbl_Lob()
            {
                IdLob = 1,
                Lob = "Lob1",
                MmcpLob = "MmcpLob",
                MmcpSegment = "MmcpSegment",
                ProductLine1 = "ProductLine1",
                ProductLine2 = "ProductLine2",
                ProductLine3 = "ProductLine3",
                SpphIdProduct = 1234
            });

            this.db.TblLob.Add(new tbl_Lob()
            {
                IdLob = 2,
                Lob = "Lob2",
                MmcpLob = "MmcpLob",
                MmcpSegment = "MmcpSegment",
                ProductLine1 = "ProductLine1",
                ProductLine2 = "ProductLine2",
                ProductLine3 = "ProductLine3",
                SpphIdProduct = 1234
            });

            this.db.TblLob.Add(new tbl_Lob()
            {
                IdLob = 3,
                Lob = "Lob3",
                MmcpLob = "MmcpLob",
                MmcpSegment = "MmcpSegment",
                ProductLine1 = "ProductLine1",
                ProductLine2 = "ProductLine2",
                ProductLine3 = "ProductLine3",
                SpphIdProduct = 1234
            });

            this.db.TblLob.Add(new tbl_Lob()
            {
                IdLob = 4,
                Lob = "Lob4",
                MmcpLob = "MmcpLob",
                MmcpSegment = "MmcpSegment",
                ProductLine1 = "ProductLine1",
                ProductLine2 = "ProductLine2",
                ProductLine3 = "ProductLine3",
                SpphIdProduct = 1234
            });

            this.db.SaveChanges();

            var service = new Lob(this.db);

            var allLobs = service.All();

            Assert.IsNotNull(allLobs);

            Assert.AreEqual(4, allLobs.Count());

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, allLobs.Select(l => l.IdLob).ToArray());
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.db = MockDbContext.GetContext();
            this.mapper = MockAutoMapper.GetMapper();
        }
    }
}
