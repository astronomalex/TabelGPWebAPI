using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabelGPWebAPI.Models;

namespace TabelGPWebAPI.Configurations
{
    public class RoleConfiguration :  IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasDefaultValueSql("newsequentialid()");
            builder.HasMany(entity => entity.Users)
                .WithOne(entity => entity.Role)
                .HasForeignKey(entity => entity.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(entity => entity.Name).IsRequired();
        }
    }
}