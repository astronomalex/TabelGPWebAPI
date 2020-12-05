using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelGPWebAPI.Models
{
    public class WorkerReport
    {
        public int Id { get; set; }
        public string TbNum { get; set; }
        public string Grade { get; set; }
        public Report Report { get; set; }
        public int ReportId { get; set; }
    }
}
