using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourse([FromBody] CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourses), new { id = course.CourseID }, courseDto);
        }
    }
}
