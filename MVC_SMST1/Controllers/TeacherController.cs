using MSTCore.Entities;
using MSTService;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MSTMVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, ICourseService courseService, IMapper mapper)
        {
            _teacherService = teacherService;
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AddTeacher()
        {
            // Kursları CourseService'den alıyoruz
            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            ViewBag.Courses = courseDtos;  // Kursları View'e taşıyoruz

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(TeacherDto teacherDto)
        {
            if (ModelState.IsValid)
            {
                var teacher = _mapper.Map<Teacher>(teacherDto);
                await _teacherService.AddTeacher(teacher);
                return RedirectToAction("Teachers");
            }

            // Post işleminde hata olursa kursları tekrar yüklemek gerekli
            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            ViewBag.Courses = courseDtos;

            return View(teacherDto);
        }

        [HttpGet]
        public async Task<IActionResult> Teachers()
        {
            var teachers = await _teacherService.GetAllTeachers();
            var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(teachers);
            return View(teacherDtos);
        }
    }
}
