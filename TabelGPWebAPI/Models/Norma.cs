using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelGPWebAPI.Models
{
    public class Norma
    {
        public int Id { get; set; }
        public string Machine { get; set; }
        public string GroupDiff { get; set; }
        public float Amount { get; set; }
    }
}
