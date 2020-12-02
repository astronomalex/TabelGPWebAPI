using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TabelGPWebAPI.Models
{
    public class WorkerTime
    {
        public int Id { get; set; }
        [Required]
        public string TbNum { get; set; }
        [Required]
        public string Grade { get; set; }
        public float SdelTime { get; set; }
        public float NightTime { get; set; }
        public float ProstTime { get; set; }
        public float PrikTime { get; set; }
        public float SrednTime { get; set; }
        public float PprTime { get; set; }
        public float DoubleTime { get; set; }
    }
}
