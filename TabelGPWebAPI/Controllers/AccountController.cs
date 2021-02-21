using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Controllers
{
    public class AccountController : ControllerBase
    {
        private ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                user = new User
                {
                    Email = model.Email,
                    Password = model.Password
                };
                _context.Users.Add(user);

                await _context.SaveChangesAsync();
                
                await 
            }
        }

        private async Task Authenticate(User user)
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults)
        }
    }
}