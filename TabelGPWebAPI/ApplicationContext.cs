using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabelGPWebAPI.Conf;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Norma> Norms { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Smena> Smens { get; set; }
        public virtual DbSet<WorkerData> WorkerDatas { get; set; }
        public virtual DbSet<WorkerReport> WorkerReport { get; set; }
        public virtual DbSet<WorkerTime> WorkerTimes { get; set; }
        public virtual DbSet<WorkUnit> WorkUnits { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SmenaConfiguration());
            modelBuilder.ApplyConfiguration(new NormaConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerTimeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
