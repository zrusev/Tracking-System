namespace Metrics_Track.Test.Mocks
{
    using Microsoft.AspNetCore.Identity;
    using Moq;

    public static class RoleManagerMock
    {
        public static Mock<RoleManager<IdentityRole>> New
            => new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
    }
}
