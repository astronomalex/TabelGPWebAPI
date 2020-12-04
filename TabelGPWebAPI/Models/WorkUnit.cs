using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TabelGPWebAPI.Models
{
    public class WorkUnit
    {
        public int Id { get; set; }
        [Required]
        public string StartWorkTime { get; set; }
        [Required]
        public string EndWorkTime { get; set; }
        public string TypeWork { get; set; }
        public string NumOrder { get; set; }
        public string NameOrder { get; set; }
        public string GroupDifficulty { get; set; }
        public int AmountDonePieces { get; set; }
        [Required]
        public Report Report { get; set; }
        [Required]
        public int ReportId { get; set; }
    }
}
