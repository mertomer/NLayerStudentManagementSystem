using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;

    public StudentController(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

  
    [HttpGet]
    public async Task<IEnumerable<StudentDto>> GetStudents()
    {
        var students = await _studentService.GetAllStudents();
        return _mapper.Map<IEnumerable<StudentDto>>(students);
    }

    
    [HttpPost]
    public async Task<ActionResult<StudentDto>> AddStudent([FromBody] StudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        await _studentService.AddStudent(student);
        return CreatedAtAction(nameof(GetStudents), new { id = student.StudentID }, studentDto);
    }
}