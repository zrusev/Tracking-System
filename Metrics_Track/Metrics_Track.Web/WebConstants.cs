namespace Metrics_Track.Web
{
    public class WebConstants
    {
        public const string AdministratorRole = "Administrator";
        public const string AgentRole = "Agent";
        public const string ManagerRole = "Manager";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";

        public const string AdminArea = "Admin";
        public const string IdentityArea = "Identity";
        public const string ManagementArea = "Management";

        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 100;

        public const int MaxItemsPerPage = 25;

        public const string SuccessfulMapping = "Mapping has been updated successfully.";
        public const string SelectSingleProcess = "Please select a single process only.";

        public const string EmailSubject = "Metrics Track account confirmation";
        public const string EmailBody = @"<p>Thank you for registering at Metrics Track.&nbsp;</p>
                                            <p>Your account has been revised and approved.</p>
                                            <p>Your current team leader is {0}.</p>
                                            <p><span class=""il"">You</span>&nbsp;may now log in to 
                                            <a href=""{1}"">Metrics Track</a> using your e-mail and password.</p>
                                            <p><strong><sup>Metrics Track team</sup></strong></p>";

    }
}