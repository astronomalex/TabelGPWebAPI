using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public NormsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Norms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Norma>>> GetNorms()
        {
            return await _context.Norms.ToListAsync();
        }

        // GET: api/Norms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Norma>> GetNorma(int id)
        {
            var norma = await _context.Norms.FindAsync(id);

            if (norma == null)
            {
                return NotFound();
            }

            return norma;
        }

        // PUT: api/Norms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNorma(int id, Norma norma)
        {
            if (id != norma.Id)
            {
                return BadRequest();
            }

            _context.Entry(norma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NormaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Norms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Norma>> PostNorma(Norma norma)
        {
            _context.Norms.Add(norma);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNorma), new { id = norma.Id }, norma);
        }

        // DELETE: api/Norms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Norma>> DeleteNorma(int id)
        {
            var norma = await _context.Norms.FindAsync(id);
            if (norma == null)
            {
                return NotFound();
            }

            _context.Norms.Remove(norma);
            await _context.SaveChangesAsync();

            return norma;
        }

        private bool NormaExists(int id)
        {
            return _context.Norms.Any(e => e.Id == id);
        }
    }
}
