namespace Metrics_Track.Services.Models.Process
{
    using Common.Mapping;
    using Common.Validation;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ProcessListModel : IMapFrom<tbl_Process>
    {
        public int IdProcess { get; set; }

        public string Process { get; set; }

        public string FunctionName { get; set; }

        public string ProcessMap { get; set; }

        [Required(ErrorMessage = ValidationConstants.SlaTargetType)]
        public string Mnc { get; set; }

        public string SlaType { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = ValidationConstants.SlaTargetType)]
        public string SlaTarget { get; set; }

        public string Level2Taxonomy { get; set; }

        public string Level3Taxonomy { get; set; }

        public string Pid { get; set; }

        public string NiceQueue { get; set; }

        public string Group { get; set; }

        public int? SpphIdProcess { get; set; }
    }
}
