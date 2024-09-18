using System.Collections.Generic;
using System.Threading.Tasks;
using MSTCore.Entities;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudents();
    Task<Student> GetStudentById(int id);
    Task AddStudent(Student student);
    Task UpdateStudent(Student student);
    Task DeleteStudent(Student student);  // Burada Task olarak düzenliyoruz
}

