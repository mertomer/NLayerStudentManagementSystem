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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // Tüm öğretmenleri getir
        [HttpGet]
        public async Task<IEnumerable<TeacherDto>> GetTeachers()
        {
            var teachers = await _teacherService.GetAllTeachers();

            // Entity'den DTO'ya mapleme
            var teacherDtos = teachers.Select(teacher => new TeacherDto
            {
                TName = teacher.TName,
                Education = teacher.Education,
                CourseID = teacher.CourseID
            });

            return teacherDtos;
        }

        // Yeni öğretmen ekle
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> AddTeacher(TeacherDto teacherDto)
        {
            // DTO'dan Entity'ye mapleme
            var teacher = new Teacher
            {
                TName = teacherDto.TName,
                Education = teacherDto.Education,
                CourseID = teacherDto.CourseID
            };

            await _teacherService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeachers), new { id = teacher.TeacherID }, teacherDto);
        }
    }
}
