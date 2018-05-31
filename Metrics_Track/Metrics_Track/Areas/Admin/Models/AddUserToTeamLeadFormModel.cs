namespace Metrics_Track.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    public class AddUserToTeamLeadFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string TeamLead { get; set; }
    }
}
