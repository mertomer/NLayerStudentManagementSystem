using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSTCore.Entities;

namespace MSTRepository.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherID);

            builder.Property(t => t.TName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Education)
                .HasMaxLength(100);
        }
    }
}
