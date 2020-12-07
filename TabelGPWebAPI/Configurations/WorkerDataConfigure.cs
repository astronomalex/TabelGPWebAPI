using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Configurations
{
    public class WorkerDataConfigure : IEntityTypeConfiguration<WorkerData>
    {
        public void Configure(EntityTypeBuilder<WorkerData> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(entity => entity.Grade).IsRequired();
            builder.Property(entity => entity.Name).IsRequired();
            builder.Property(entity => entity.Surname).IsRequired();
            builder.Property(entity => entity.TableNum).IsRequired();
        }
    }
}