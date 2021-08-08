using System;
using System.Collections.Generic;

namespace TabelGPWebAPI.Entities
{
    public class Report
    {
        public Guid Id { get; set; }

        public Machine Machine { get; set; }
        public Guid MachineId { get; set; }

        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }

        public DateTime DateReport { get; set; }
        public string NumShiftReport { get; set; }
        public float PercentOfReport { get; set; }

        public ICollection<WorkerReport> WorkersOfReport { get; set; }
        public ICollection<WorkReport> WorksOfReport { get; set; }
    }
}