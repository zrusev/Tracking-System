namespace Metrics_Track.Services.Models.Division
{
    using Common.Mapping;
    using Data.Models;

    public class DivisionModel : IMapFrom<tbl_Division>
    {
        public int IdDivision { get; set; }

        public string Division { get; set; }
    }
}
