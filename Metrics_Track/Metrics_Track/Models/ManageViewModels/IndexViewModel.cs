namespace Metrics_Track.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class IndexViewModel
    {
        [Required]
        [Display(Name= "First Name")]
        [MinLength(WebConstants.UserNameMinLength)]
        [MaxLength(WebConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(WebConstants.UserNameMinLength)]
        [MaxLength(WebConstants.UserNameMaxLength)]
        public string LastName { get; set; }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //[Phone]
        //[Display(Name = "Phone number")]
        //public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
