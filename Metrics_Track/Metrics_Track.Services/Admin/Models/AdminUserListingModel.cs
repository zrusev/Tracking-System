namespace Metrics_Track.Services.Admin.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class AdminUserListingModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public int? IdTeamLead { get; set; }

        public string TeamLead { get; set; }

        public short Sandbox { get; set; }

        public int IdLogin { get; set; }

        public List<tbl_Country> Countries { get; set; } = new List<tbl_Country>();
    }
}
