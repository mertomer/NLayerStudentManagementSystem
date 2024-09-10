using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSTCore.Entities;

namespace MSTRepository.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentID);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.PersonalDetail)
                .HasMaxLength(250);

            builder.Property(s => s.EducationDetail)
                .HasMaxLength(100);

            builder.Property(s => s.FeesDetail)
                .HasMaxLength(100);
        }
    }
}
