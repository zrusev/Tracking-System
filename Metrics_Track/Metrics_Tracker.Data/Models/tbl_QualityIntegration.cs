namespace Metrics_Track.Data.Models
{
    public class tbl_QualityIntegration
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public double? QualityPtsScored { get; set; }
        public double? QualityPtsTotal { get; set; }
    }
}
