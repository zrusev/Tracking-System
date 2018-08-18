namespace Metrics_Track.Services.Models.User
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;

    public class TeamLeadListingModel : IMapFrom<tbl_TeamLead>
    {
        public int IdTeamLead { get; set; }

        public string TeamLead { get; set; }
    }
}
