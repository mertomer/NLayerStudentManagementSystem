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

        // GET: AddStudent
        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            ViewBag.Courses = courseDtos;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(studentDto);
                student.FeesDetail = studentDto.FeesDetail;

                await _studentService.AddStudent(student);
                return RedirectToAction("Students");
            }

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

        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            var studentDto = _mapper.Map<StudentDto>(student);

            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            ViewBag.Courses = courseDtos;

            return View(studentDto);
        }

        
        [HttpPost]
        public async Task<IActionResult> EditStudent(int id, StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                var student = await _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }

                student.Name = studentDto.Name;
                student.PersonalDetail = studentDto.PersonalDetail;
                student.EducationDetail = studentDto.EducationDetail;
                student.FeesDetail = studentDto.FeesDetail;
                student.CourseID = studentDto.CourseID; 

                await _studentService.UpdateStudent(student);
                return RedirectToAction("Students");
            }

            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            ViewBag.Courses = courseDtos;

            return View(studentDto);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentService.DeleteStudent(student);
            return RedirectToAction("Students");
        }
    }
}
