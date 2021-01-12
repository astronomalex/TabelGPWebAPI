using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Configurations
{
    public class WorkerTimeConfiguration : IEntityTypeConfiguration<WorkerTime>
    {
        public void Configure(EntityTypeBuilder<WorkerTime> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            // builder.HasOne(entity => entity.Smena)
            //     .WithMany(entity => entity.WorkerTimes)
            //     .HasForeignKey(entity => entity.SmenaId)
            //     .IsRequired()
            //     .OnDelete(DeleteBehavior.NoAction);
            builder.Property(entity => entity.TbNum).IsRequired();
            builder.Property(entity => entity.Grade).IsRequired();
            
        }
    }
}