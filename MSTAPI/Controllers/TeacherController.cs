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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TeacherDto>> GetTeachers()
        {
            var teachers = await _teacherService.GetAllTeachers();
            return _mapper.Map<IEnumerable<TeacherDto>>(teachers);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherDto>> AddTeacher([FromBody] TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            await _teacherService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeachers), new { id = teacher.TeacherID }, teacherDto);
        }
    }
}
