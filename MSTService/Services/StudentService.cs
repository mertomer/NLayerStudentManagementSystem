using MSTCore.Entities;
using MSTRepository;

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

    public async Task UpdateStudent(Student student)
    {
        _studentRepository.Update(student);
        await _studentRepository.SaveAsync();
    }

    public async Task DeleteStudent(Student student)  // Task olarak değiştirildi
    {
        _studentRepository.Delete(student);
        await _studentRepository.SaveAsync();  // Değişikliği burada da await ile işliyoruz
    }
}
