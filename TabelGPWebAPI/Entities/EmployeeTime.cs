using System;

namespace TabelGPWebAPI.Entities
{
    public class EmployeeTime
    {
        public Guid Id { get; set; }
        public float DoublePayTime { get; set; }
        public float NightTime { get; set; }
        public float PprTime { get; set; }
        public float PrikTime { get; set; }
        public float ProstTime { get; set; }
        public float SdelTime { get; set; }
        public float SrednTime { get; set; }
        public int Grade { get; set; }
        
        public Employee Employee { get; set; }
        public Guid EmployeeId { set; get; }
        
        public Shift Shift { get; set; }
        public Guid ShiftId { get; set; }
    }
}