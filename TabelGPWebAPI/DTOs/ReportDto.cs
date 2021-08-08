using System.Collections.Generic;

namespace TabelGPWebAPI.DTOs
{
    public class ReportDto
    {
        public string DateReport { get; set; }
        public string Machine { get; set; }
        public string NumSmenReport { get; set; }
        public float PercentOfReport { get; set; }
        public ICollection<WorkerReportDto> WorkerListReport { get; set; }
        public ICollection<WorkReportDto> WorkListReport { get; set; }
    }
}