using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            builder.HasMany(entity => entity.WorkUnits)
                .WithOne(entity => entity.Report)
                .HasForeignKey(entity => entity.ReportId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(entity => entity.Machine).IsRequired();
            builder.Property(entity => entity.DateReport).IsRequired();
            builder.Property(entity => entity.NumSmenReport).IsRequired();
            builder.Property(entity => entity.WorkUnits).IsRequired();
            builder.Property(entity => entity.WorkerListReports).IsRequired();
        }
    }
}