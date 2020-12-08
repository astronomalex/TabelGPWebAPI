using System.Collections;
using System.Collections.Generic;
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

        [HttpGet("{date/machine}")]
        public async Task<ActionResult<Smena>> GetSmena(string date, string machine)
        {
            
        }
    }
}