using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Configurations
{
    public class WorkUnitConfiguration : IEntityTypeConfiguration<WorkUnit>
    {
        public void Configure(EntityTypeBuilder<WorkUnit> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            // builder.HasOne(entity => entity.Report)
            //     .WithMany(entity => entity.WorkUnits)
            //     .HasForeignKey(entity => entity.ReportId)
            //     .IsRequired()
            //     .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}