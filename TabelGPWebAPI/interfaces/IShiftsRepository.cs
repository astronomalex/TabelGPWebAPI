using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Entities;

namespace TabelGPWebAPI.interfaces
{
    public interface IShiftsRepository
    {
        Task<ICollection<ShiftDto>> GetShiftsByUsername(string username);
        Task<int> SaveShiftsAsync(ICollection<ShiftDto> shiftDtos, string username);
    }
}