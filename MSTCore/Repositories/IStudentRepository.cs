using MSTCore.Entities;

namespace MSTRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetStudentWithCoursesAsync(int studentId);
    }
}
