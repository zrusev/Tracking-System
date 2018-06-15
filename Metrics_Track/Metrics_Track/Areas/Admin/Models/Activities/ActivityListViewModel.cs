namespace Metrics_Track.Areas.Admin.Models.Activities
{
    using Metrics_Track.Services.Models.Activity;
    using System.Collections.Generic;
    public class ActivityListViewModel
    {
        public IEnumerable<ActivityModel> ActivityList { get; set; } = new List<ActivityModel>();
    }
}
