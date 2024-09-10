using Microsoft.EntityFrameworkCore;
using MSTCore.Entities;
using System.Threading.Tasks;

namespace MSTRepository.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Student> GetStudentWithCoursesAsync(int studentId)
        {
            return await _context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.StudentID == studentId);
        }
    }
}
