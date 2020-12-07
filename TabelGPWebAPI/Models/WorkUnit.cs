using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TabelGPWebAPI.Models
{
    public class WorkUnit
    {
        public Guid Id { get; set; }
        public string StartWorkTime { get; set; }
        public string EndWorkTime { get; set; }
        public string TypeWork { get; set; }
        public string NumOrder { get; set; }
        public string NameOrder { get; set; }
        public string GroupDifficulty { get; set; }
        public int AmountDonePieces { get; set; }
        public virtual Report Report { get; set; }
        public Guid ReportId { get; set; }
    }
}
