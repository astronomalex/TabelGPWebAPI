using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TabelGPWebAPI
{
    public class Norma
    {
        public int Id { get; set; }
        [Required]
        public string Machine { get; set; }
        public string GroupDiff { get; set; }
        public float Amount { get; set; }
    }
}
