using System;
using System.Collections.Generic;

namespace TabelGPWebAPI.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string TabelNum { get; set; }
        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public ICollection<EmployeeTime> EmployeeTimes { get; set; }
        public ICollection<WorkerReport> WorkerReports { get; set; }
    }
}