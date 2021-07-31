using System.Collections;
using System.Collections.Generic;

namespace TabelGPWebAPI.DTOs
{
    public class ShiftDto
    {
        public string DateSmen { get; set; }
        public string Mashine { get; set; }
        public string NumSmen { get; set; }
        public ICollection<EmployeeTimeDto> WorkersTime { get; set; }
    }
}