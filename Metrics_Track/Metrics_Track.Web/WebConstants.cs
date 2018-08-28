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

        public const string InvalidTransactionMapping = "Invalid transaction mapping.";
        public const string InvalidTransactionId = "Invalid transaction id.";
        public const string MissingTransaction = "Could not find this transaction.";
        public const string WrongAssignment = "The transaction has been assigned to somebody else.";
        public const string WrongTransactionStatus = "The transaction is no longer pending.";

        public const string InvalidIdentityDetails = "Invalid identity details.";
        public const string InvalidUserId = "User not found. Invalid ID.";
        public const string InvalidModelDetails = "Invalid model details.";
        public const string InvalidSelfModifications = "Self modifications are not allowed.";
        public const string RemovedUser = "User removed successfully.";

        public const string InvalidStatusDetails = "Invalid status details.";
        public const string InvalidStatusId = "Invalid status id.";

        public const string InvalidProcessDetails = "Invalid process details.";
        public const string InvalidProcessId = "Invalid process id.";

        public const string InvalidLobDetails = "Invalid lob details.";
        public const string InvalidLobId = "Invalid lob id.";

        public const string InvalidDivisionDetails = "Invalid division details.";
        public const string InvalidDivisionId = "Invalid division id.";

        public const string InvalidActivityDetails = "Invalid activity details.";
        public const string InvalidActivityId = "Invalid activity id.";

        public const string InvalidCountryRemoving = "Removing countries is not allowed.";
        public const string MultipleCountriesSelection = "Please select a single country only.";

        public const string InvalidReceivedDate = "Received date can not be later than Complete date.";
        public const string MissingRecords = "No records have been found for this period.";
    }
}