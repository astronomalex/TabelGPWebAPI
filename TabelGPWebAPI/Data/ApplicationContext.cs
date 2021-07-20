using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.Entities;

namespace TabelGPWebAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Norma> Norms { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Machine> Machines { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Norma>()
                .HasOne(n => n.Machine)
                .WithMany(m => m.NormsByMashine)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Norma>()
                .HasOne(n => n.User)
                .WithMany(u => u.NormsByUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
