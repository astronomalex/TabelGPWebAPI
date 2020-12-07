using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerDatasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WorkerDatasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WorkerDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerData>>> GetWorkerDatas()
        {
            return await _context.WorkerDatas.ToListAsync();
        }

        // GET: api/WorkerDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerData>> GetWorkerData(int id)
        {
            var workerData = await _context.WorkerDatas.FindAsync(id);

            if (workerData == null)
            {
                return NotFound();
            }

            return workerData;
        }

        // PUT: api/WorkerDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkerData(Guid id, WorkerData workerData)
        {
            if (id != workerData.Id)
            {
                return BadRequest();
            }

            _context.Entry(workerData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerDataExists(id))
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

        // POST: api/WorkerDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkerData>> PostWorkerData(WorkerData workerData)
        {
            _context.WorkerDatas.Add(workerData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkerData", new { id = workerData.Id }, workerData);
        }

        // DELETE: api/WorkerDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkerData>> DeleteWorkerData(int id)
        {
            var workerData = await _context.WorkerDatas.FindAsync(id);
            if (workerData == null)
            {
                return NotFound();
            }

            _context.WorkerDatas.Remove(workerData);
            await _context.SaveChangesAsync();

            return workerData;
        }

        private bool WorkerDataExists(Guid id)
        {
            return _context.WorkerDatas.Any(e => e.Id == id);
        }
    }
}
