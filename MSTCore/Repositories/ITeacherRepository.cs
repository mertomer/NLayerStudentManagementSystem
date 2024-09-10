using MSTCore.Entities;

namespace MSTRepository
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<Teacher> GetTeacherWithCoursesAsync(int teacherId);
    }
}
