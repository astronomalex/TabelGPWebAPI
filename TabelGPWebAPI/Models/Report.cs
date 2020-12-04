﻿using System;
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
        public ICollection<WorkerListReport> WorkerListReports { get; set; }
        public ICollection<int> WorkerListReportId { get; set; }
        public string NumSmenReport { get; set; }
        public ICollection<WorkUnit> WorkUnits { get; set; }
        public ICollection<int> WorkUnitsId { get; set; }
        public float PersentOfReport { get; set; }
    }
}
