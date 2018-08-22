namespace Metrics_Track.Services.Models.User
{
    using Common.Mapping;
    using Data.Models;

    public class TeamLeadListingModel : IMapFrom<tbl_TeamLead>
    {
        public int IdTeamLead { get; set; }

        public string TeamLead { get; set; }
    }
}
