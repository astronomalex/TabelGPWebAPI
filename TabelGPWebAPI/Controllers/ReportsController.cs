using System;
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
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        
        public ReportsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            return await _context.Reports.ToListAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(Report report)
        {
            if (report == null)
                return BadRequest();

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return Ok(report);
        }

        [HttpPut]
        public async Task<ActionResult<Report>> UpdateReport(Report report)
        {
            if (report == null)
            {
                return BadRequest();
            }

            if (!_context.Smens.Any(s => s.Id == report.Id))
            {
                return NotFound();
            }

            _context.Update(report);
            await _context.SaveChangesAsync();
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Report>> DeleteReport(Guid id)
        {
            Report report = _context.Reports.FirstOrDefault(r => r.Id == id);
            if (report == null)
                return NotFound();

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return Ok(report);
        }
    }
}