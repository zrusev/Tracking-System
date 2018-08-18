namespace Metrics_Track.Data.Models
{
    using System;

    public class tbl_HolidayTable
    {
        public int Id { get; set; }

        public string FunctionName { get; set; }

        public string Country { get; set; }

        public string TeamLead { get; set; }

        public DateTime? HolidayDate { get; set; }
    }
}
