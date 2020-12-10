using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Configurations
{
    public class WorkerReportConfiguration : IEntityTypeConfiguration<WorkerReport>
    {
        public void Configure(EntityTypeBuilder<WorkerReport> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            // builder.HasOne(entity => entity.Report)
            //     .WithMany(entity => entity.WorkerListReports)
            //     .HasForeignKey(entity => entity.ReportId)
            //     .IsRequired()
            //     .OnDelete(DeleteBehavior.NoAction);
        }
    }
}