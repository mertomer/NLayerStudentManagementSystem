using Microsoft.EntityFrameworkCore;
using MSTCore.Entities;
using System.Threading.Tasks;

namespace MSTRepository.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Teacher> GetTeacherWithCoursesAsync(int teacherId)
        {
            return await _context.Teachers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.TeacherID == teacherId);
        }
    }
}
