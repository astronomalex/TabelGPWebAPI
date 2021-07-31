using System;
using System.Collections.Generic;

namespace TabelGPWebAPI.Entities
{
    public class Shift
    {
        public Guid Id { get; set; }
        public DateTime DateShift { get; set; }
        public string NumShift { get; set; }

        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }
        
        public Machine Machine { get; set; }
        public Guid MachineId { get; set; }

        public ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}