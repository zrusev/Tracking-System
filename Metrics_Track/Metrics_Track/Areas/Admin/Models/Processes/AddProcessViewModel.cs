namespace Metrics_Track.Areas.Admin.Models.Processes
{
    using System.ComponentModel.DataAnnotations;
    public class AddProcessViewModel
    {
        public string Process { get; set; }

        public string FunctionName { get; set; }

        public string ProcessMap { get; set; }

        [Required(ErrorMessage = "MNC can not be empty.")]
        public string Mnc { get; set; }

        public string SlaType { get; set; }

        public string SlaTarget { get; set; }

        public string Level2Taxonomy { get; set; }

        public string Level3Taxonomy { get; set; }

        public string Pid { get; set; }

        public string NiceQueue { get; set; }

        public string Group { get; set; }

        public int? SpphIdProcess { get; set; }
    }
}
