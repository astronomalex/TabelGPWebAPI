using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Extensions;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Controllers
{
    [Authorize]
    public class ShiftsController : BaseApiController
    {
        private readonly IShiftsRepository _repository;

        public ShiftsController(IShiftsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> SaveShifts(ICollection<ShiftDto> shiftDtos)
        {
            var username = User.GetUsername();
            var result = await _repository.SaveShiftsAsync(shiftDtos, username);
            if (result != -1)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ShiftDto>>> GetShifts()
        {
            return Ok(await _repository.GetShiftsByUsername(User.GetUsername()));
        }
    }
}