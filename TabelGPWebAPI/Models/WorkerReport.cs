using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelGPWebAPI.Models
{
    public class WorkerReport
    {
        public Guid Id { get; set; }
        public string TbNum { get; set; }
        public string Grade { get; set; }
        public virtual Report Report { get; set; }
        public Guid ReportId { get; set; }
    }
}
