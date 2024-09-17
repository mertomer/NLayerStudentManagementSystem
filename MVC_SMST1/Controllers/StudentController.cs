using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;

namespace MSTMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
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