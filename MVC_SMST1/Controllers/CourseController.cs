using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(courseDto);
                await _courseService.AddCourse(course);
                return RedirectToAction("Courses");
            }

            return View(courseDto);
        }

        [HttpGet]
        public async Task<IActionResult> Courses()
        {
            var courses = await _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return View(courseDtos);
        }
    }
}
