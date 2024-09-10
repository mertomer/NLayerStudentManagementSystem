using System.Collections.Generic;
using System.Threading.Tasks;
using MSTCore.Entities;
using MSTRepository;

namespace MSTService
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentService(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task AddStudent(Student student)
        {
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveAsync();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
            _studentRepository.SaveAsync();
        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
            _studentRepository.SaveAsync();
        }
    }
}
