using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelGPWebAPI.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string DateReport { get; set; }
        public string Machine { get; set; }
        public WorkerListReport[] WorkerListReports { get; set; }
        public string NumSmenReport { get; set; }
        public WorkUnit[] workListReport { get; set; }
        public ICollection<int> workListReportId { get; set; }
        public float PersentOfReport { get; set; }
    }
}
