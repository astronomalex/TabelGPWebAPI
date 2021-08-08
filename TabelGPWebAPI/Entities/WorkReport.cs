using System;

namespace TabelGPWebAPI.Entities
{
    public class WorkReport
    {
        public Guid Id { get; set; }

        public Report Report { get; set; }
        public Guid ReportId { get; set; }

        public float AmountPiecesDone { get; set; }
        public string StartWorkTime { get; set; }
        public string EndWorkTime { get; set; }
        public float GroupDifficulty { get; set; }
        public string NameOrder { get; set; }
        public string NumOrder { get; set; }
        public string TypeWork { get; set; }
    }
}