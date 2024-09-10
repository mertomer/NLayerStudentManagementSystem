using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentService.GetAllStudents();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();

            return student;
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> AddStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                PersonalDetail = studentDto.PersonalDetail,
                EducationDetail = studentDto.EducationDetail,
                FeesDetail = studentDto.FeesDetail,
                CourseID = studentDto.CourseID
            };

            await _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentID }, studentDto);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (id != student.StudentID)
                return BadRequest();

            _studentService.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentById(id).Result;
            if (student == null)
                return NotFound();

            _studentService.DeleteStudent(student);
            return NoContent();
        }
    }
}
