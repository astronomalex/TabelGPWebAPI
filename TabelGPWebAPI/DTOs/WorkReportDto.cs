namespace TabelGPWebAPI.DTOs
{
    public class WorkReportDto
    {
        public float AmountDonePieces { get; set; }
        public string StartWorkTime { get; set; }
        public string EndWorkTime { get; set; }
        public float GroupDifficulty { get; set; }
        public string NameOrder { get; set; }
        public string NumOrder { get; set; }
        public string TypeWork { get; set; }
    }
}