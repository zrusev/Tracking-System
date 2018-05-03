namespace Metrics_Track.Data.Models
{
    public class tbl_Objects
    {
        public int IdObject { get; set; }
        public int IdCountry { get; set; }
        public string ObjectType { get; set; }
        public string Location { get; set; }
        public string ObjectName { get; set; }
        public string IsVisible { get; set; }
        public string CaptureText { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? PositionTop { get; set; }
        public double? PositionLeft { get; set; }
        public string FieldName { get; set; }
    }
}
