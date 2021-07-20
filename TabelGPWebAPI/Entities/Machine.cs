using System;
using System.Collections;
using System.Collections.Generic;

namespace TabelGPWebAPI.Entities
{
    public class Machine
    {
        public Guid Id { get; set; }
        public string MachineName { get; set; }
        public ICollection<Norma> NormsByMashine { get; set; } = new List<Norma>();
    }
}