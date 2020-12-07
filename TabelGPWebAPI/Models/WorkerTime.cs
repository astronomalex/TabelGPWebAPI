using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TabelGPWebAPI.Models
{
    public class WorkerTime
    {
        public Guid Id { get; set; }
        public string TbNum { get; set; }
        public string Grade { get; set; }
        public float SdelTime { get; set; }
        public float NightTime { get; set; }
        public float ProstTime { get; set; }
        public float PrikTime { get; set; }
        public float SrednTime { get; set; }
        public float PprTime { get; set; }
        public float DoubleTime { get; set; }
        public Smena Smena { get; set; }
        public Guid SmenaId { get; set; }
    }
}
