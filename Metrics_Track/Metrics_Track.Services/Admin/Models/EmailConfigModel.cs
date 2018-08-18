﻿namespace Metrics_Track.Services.Admin.Models
{
    using System;

    public class EmailConfigModel
    {
        public string FromName { get; set; }

        public string FromAddress { get; set; }

        public string LocalDomain { get; set; }

        public string MailServerAddress { get; set; }

        public string MailServerPort { get; set; }

        public string UserId { get; set; }

        public string UserPassword { get; set; }

        public string AdminEmailAddress { get; set; }
    }
}
