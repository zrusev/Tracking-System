namespace Metrics_Track.Common.Validation
{
    using System;

    public static class Validator
    {
        public static void EnsureNotNull(object obj, string message = "")
        {
            if (obj == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
