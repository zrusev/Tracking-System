namespace Metrics_Track.Web.Areas.Management.Pages
{
    using Services.Contracts;
    using Services.Models.Status;
    using System.Collections.Generic;

    public class CurrentStatusModel : ManagementModel
    {
        private readonly IStatus status;

        public CurrentStatusModel(IStatus status)
        {
            this.status = status;
        }

        public IEnumerable<CurrentStatusListModel> Statuses { get; set; }

        public void OnGet()
        {
            this.Statuses = this.status.AllCurrentStatuses();
        }
    }
}