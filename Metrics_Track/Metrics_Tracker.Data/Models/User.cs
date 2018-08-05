namespace Metrics_Track.Data.Models
{
    using Metrics_Track.Data.Constants;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string LastName { get; set; }

        public int? IdTeamLead { get; set; }

        public tbl_TeamLead TeamLead { get; set; }

        public short Sandbox { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogin { get; set; }

        public List<trel_AgentCountry> Countries { get; set; } =  new List<trel_AgentCountry>();
    }
}