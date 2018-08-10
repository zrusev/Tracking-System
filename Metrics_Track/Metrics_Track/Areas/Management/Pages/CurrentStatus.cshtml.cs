namespace Metrics_Track.Areas.Management.Pages
{
    using Metrics_Track.Services.Contracts;
    using Metrics_Track.Services.Models.Status;
    using System.Collections.Generic;

    public class CurrentStatusModel : SandboxModel
    {
        private readonly IStatus status;

        public CurrentStatusModel(IStatus status)
        {
            this.status = status;
        }

        public IEnumerable<CurrentStatusListModel> Statuses{ get; set; }

        public void OnGet()
        {
            this.Statuses = this.status.AllCurrentStatuses();
        }
    }
}