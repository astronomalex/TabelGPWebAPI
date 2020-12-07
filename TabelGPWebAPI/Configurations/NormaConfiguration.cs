using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TabelGPWebAPI.Conf
{
    public class NormaConfiguration : IEntityTypeConfiguration<Norma>
    {
        public void Configure(EntityTypeBuilder<Norma> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(entity => entity.Amount).IsRequired();
            builder.Property(entity => entity.Machine).IsRequired();
            builder.Property(entity => entity.GroupDiff).IsRequired();
        }
    }
}