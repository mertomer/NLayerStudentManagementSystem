using MSTCore.Entities;
using MSTRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTService
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public CourseService(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task AddCourse(Course course)
        {
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveAsync();
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
            _courseRepository.SaveAsync();
        }

        public void DeleteCourse(Course course)
        {
            _courseRepository.Delete(course);
            _courseRepository.SaveAsync();
        }
    }
}
