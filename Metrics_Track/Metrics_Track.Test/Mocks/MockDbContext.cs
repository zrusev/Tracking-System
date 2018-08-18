namespace Metrics_Track.Test
{
    using Metrics_Track.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class MockDbContext
    {
        public static TrackerDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<TrackerDbContext>()                
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new TrackerDbContext(options);
        }
    }
}
