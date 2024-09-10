using MSTCore.Entities;

namespace MSTRepository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetCourseWithDetailsAsync(int courseId);
    }
}
