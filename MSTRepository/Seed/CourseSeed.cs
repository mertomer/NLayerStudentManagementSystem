using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSTCore.Entities;

namespace MSTRepository.Seeds
{
    internal class CourseSeed : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    CourseID = 1,
                    CourseName = "Computer Science 101",
                    Fees = 500.00m,
                    Duration = 4  // Süresi ay olarak
                },
                new Course
                {
                    CourseID = 2,
                    CourseName = "Mathematics 101",
                    Fees = 300.00m,
                    Duration = 3  // Süresi ay olarak
                },
                new Course
                {
                    CourseID = 3,
                    CourseName = "Physics 101",
                    Fees = 400.00m,
                    Duration = 5  // Süresi ay olarak
                }
            );
        }
    }
}
