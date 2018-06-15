namespace Metrics_Track.Services.Models.Division
{
    using Metrics_Track.Common.Mapping;
    using Metrics_Track.Data.Models;
    public class DivisionModel : IMapFrom<tbl_Division>
    {
        public int IdDivision { get; set; }

        public string Division { get; set; }
    }
}
