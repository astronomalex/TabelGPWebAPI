using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Norma> Norms { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Smena> Smens { get; set; }
        public DbSet<WorkerData> WorkerDatas { get; set; }
        public DbSet<WorkerListReport> WorkerListReports { get; set; }
        public DbSet<WorkerTime> WorkerTimes { get; set; }
        public DbSet<WorkUnit> WorkUnits { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
