using MSTCore.Entities;
using MSTRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTService
{
    public class TeacherService : ITeacherService
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public TeacherService(IGenericRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task AddTeacher(Teacher teacher)
        {
            await _teacherRepository.AddAsync(teacher);
            await _teacherRepository.SaveAsync();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
            _teacherRepository.SaveAsync();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
            _teacherRepository.SaveAsync();
        }
    }
}
