namespace Metrics_Track.Services.Admin.Models
{
    using System;
    public class EmailConfigModel
    {
        public String FromName { get; set; }

        public String FromAddress { get; set; }

        public String LocalDomain { get; set; }

        public String MailServerAddress { get; set; }

        public String MailServerPort { get; set; }

        public String UserId { get; set; }

        public String UserPassword { get; set; }

        public string AdminEmailAddress { get; set; }
    }
}
