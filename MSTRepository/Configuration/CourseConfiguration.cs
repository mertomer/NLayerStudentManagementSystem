using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSTCore.Entities;

namespace MSTRepository.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseID);

            builder.Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Fees)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Duration)
                .IsRequired();
        }
    }
}
