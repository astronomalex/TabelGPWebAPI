using System;

namespace TabelGPWebAPI.Entities
{
    public class Norma
    {
        public Guid Id { get; set; }
        public Machine Machine { get; set; }
        public Guid MachineId { get; set; }
        public string GroupDiff { get; set; }
        public float Amount { get; set; }
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
    }
}
