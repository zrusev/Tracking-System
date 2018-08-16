namespace Metrics_Track.Web.Areas.Admin.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class AddUserToTeamLeadFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string IdTeamLead { get; set; }
    }
}
