namespace Metrics_Track.Web.Areas.Admin.Models.Activities
{
    using Services.Models.Activity;
    using System.Collections.Generic;

    public class ActivityListViewModel
    {
        public IEnumerable<ActivityModel> ActivityList { get; set; } = new List<ActivityModel>();
    }
}
