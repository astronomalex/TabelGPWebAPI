﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelGPWebAPI.Models
{
    public class Smena
    {
        public int Id { get; set; }
        public string DateSmen { get; set; }
        public string Machine { get; set; }
        public string NumSmen { get; set; }
        public ICollection<WorkerTime> WorkerTimes {get; set;}
        //public ICollection<int> WorkerTimesId { get; set; }
    }
}
