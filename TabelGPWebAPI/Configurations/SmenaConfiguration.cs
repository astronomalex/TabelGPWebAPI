using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Configurations
{
    public class SmenaConfiguration : IEntityTypeConfiguration<Smena>
    {
        public void Configure(EntityTypeBuilder<Smena> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            builder.HasMany(entity => entity.WorkerTimes)
                .WithOne(entity => entity.Smena)
                .HasForeignKey(entity => entity.SmenaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(entity => entity.Machine).IsRequired();
            builder.Property(entity => entity.DateSmen).IsRequired();
            builder.Property(entity => entity.NumSmen).IsRequired();
        }
    }
}