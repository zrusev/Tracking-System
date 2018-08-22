namespace Metrics_Track.Services.Models.User
{
    using Common.Mapping;
    using Data.Models;

    public class UserDetailsModel : IMapFrom<User>
    {
        public int IdLogin { get; set; }

        public short Sandbox { get; set; }
    }
}
