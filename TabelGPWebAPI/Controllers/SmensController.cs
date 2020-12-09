using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SmensController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SmensController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Smena>>> GetSmens()
        {
            return await _context.Smens.ToListAsync();
        }

        [HttpGet("{machine}/{date}")]
        public async Task<ActionResult<Smena>> GetSmena(string machine, string date)
        {
            var smena = await _context.Smens.FirstOrDefaultAsync(s => s.Machine == machine && s.DateSmen == date);
            if (smena == null)
            {
                return NotFound();
            }
            
            return Ok(smena);
        }
        // {
        //     var smena = await _context.Smens.Where(s => (s.Machine == machine && s.DateSmen == date)).ToListAsync();
        //     if (smena[0] == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return smena[0];
        // }

        [HttpPost]
        public async Task<ActionResult<Smena>> PostSmena(Smena smena)
        {
            if (smena == null)
            {
                return BadRequest();
            }

            await _context.Smens.AddAsync(smena);
            await _context.SaveChangesAsync();
            return Ok(smena);
        }

        [HttpPut]
        public async Task<ActionResult<Smena>> UpdateSmena(Smena smena)
        {
            if (smena == null)
            {
                return BadRequest();
            }

            if (!_context.Smens.Any(s => s.Id == smena.Id))
            {
                return NotFound();
            }

            _context.Update(smena);
            await _context.SaveChangesAsync();
            return Ok(smena);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Smena>> DeleteSmena(Guid id)
        {
            Smena smena = _context.Smens.FirstOrDefault(s => s.Id == id);
            if (smena == null)
            {
                return NotFound();
            }

            _context.Smens.Remove(smena);
            await _context.SaveChangesAsync();
            return Ok(smena);
        }
    }
}