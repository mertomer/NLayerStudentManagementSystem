using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSTCore.Entities;
using MSTService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTMVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
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
