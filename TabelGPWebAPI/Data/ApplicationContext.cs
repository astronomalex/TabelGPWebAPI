using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.Entities;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Norma> Norms { get; set; }
        public DbSet<AppUser> Users { get; set; }
        

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
