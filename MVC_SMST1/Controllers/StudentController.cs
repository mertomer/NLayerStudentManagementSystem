using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;

    public StudentController(IStudentService studentService, ICourseService courseService, IMapper mapper)
    {
        _studentService = studentService;
        _courseService = courseService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> AddStudent()
    {
        var courses = await _courseService.GetAllCourses(); 
        var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
        ViewData["Courses"] = courseDtos ?? new List<CourseDto>(); 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(StudentDto studentDto)
    {
        if (ModelState.IsValid)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentService.AddStudent(student);
            return RedirectToAction("Students");
        }
        var courses = await _courseService.GetAllCourses();
        ViewData["Courses"] = _mapper.Map<IEnumerable<CourseDto>>(courses) ?? new List<CourseDto>();
        return View(studentDto);
    }
}
