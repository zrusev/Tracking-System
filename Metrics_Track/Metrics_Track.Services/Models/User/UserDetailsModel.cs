namespace Metrics_Track.Services.Models.User
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;

    public class UserDetailsModel : IMapFrom<User>
    {
        public int IdLogin { get; set; }

        public short Sandbox { get; set; }
    }
}
