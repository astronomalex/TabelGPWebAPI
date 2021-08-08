using System;

namespace TabelGPWebAPI.Entities
{
    public class WorkerReport
    {
        public Guid Id { get; set; }
        public int Grade { get; set; }

        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public Report Report { get; set; }
        public Guid ReportId { get; set; }
    }
}