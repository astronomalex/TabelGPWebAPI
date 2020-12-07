using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelGPWebAPI.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public string DateReport { get; set; }
        public string Machine { get; set; }
        public ICollection<WorkerReport> WorkerListReports { get; set; }
        public string NumSmenReport { get; set; }
        public ICollection<WorkUnit> WorkUnits { get; set; }
        //public ICollection<int> workListReportId { get; set; }
        public decimal PersentOfReport { get; set; }
    }
}
