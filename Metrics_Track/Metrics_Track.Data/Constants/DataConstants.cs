namespace Metrics_Track.Data.Constants
{
    public class DataConstants
    {
        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 100;

        public const string LanIdValidation = @"^[^\\\/]+$";
        public const string LanIdValidationMessage = "Lan ID should not contain '\\' or '/' character.";
    }
}
