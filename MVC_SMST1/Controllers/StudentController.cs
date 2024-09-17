using MSTCore.Entities;
using MSTService;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MSTMVC.Controllers
{
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
            // Kursları CourseService'den alıyoruz
            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            ViewBag.Courses = courseDtos;  // Kursları View'e taşıyoruz

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

            // Post işleminde hata olursa kursları tekrar yüklemek gerekli
            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            ViewBag.Courses = courseDtos;

            return View(studentDto);
        }

        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var students = await _studentService.GetAllStudents();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return View(studentDtos);
        }
    }
}
