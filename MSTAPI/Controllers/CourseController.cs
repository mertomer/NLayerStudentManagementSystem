using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();

            // Entity'den DTO'ya mapleme
            var courseDtos = courses.Select(course => new CourseDto
            {
                CourseName = course.CourseName,
                Fees = course.Fees,
                Duration = course.Duration
            });

            return courseDtos;
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourse(CourseDto courseDto)
        {
            // DTO'dan Entity'ye mapleme
            var course = new Course
            {
                CourseName = courseDto.CourseName,
                Fees = courseDto.Fees,
                Duration = courseDto.Duration
            };

            await _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourses), new { id = course.CourseID }, courseDto);
        }
    }
}
