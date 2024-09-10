using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSTCore.Entities;

namespace MSTRepository.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.AdminID);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.LoginName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
