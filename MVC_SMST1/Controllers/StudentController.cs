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

        // Öğrenci ekleme ekranını getirme işlemi (GET)
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View(); // Bu metot formu gösterir
        }

        // Öğrenci ekleme işlemi (POST)
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            if (ModelState.IsValid) // Validasyon doğruysa
            {
                var student = _mapper.Map<Student>(studentDto); // DTO'yu Entity'ye çeviriyoruz
                await _studentService.AddStudent(student); // Servis üzerinden öğrenci ekleniyor
                return RedirectToAction("Students"); // Başarılı ekleme sonrası öğrenci listesine yönlendirme
            }
            return View(studentDto); // Eğer validasyon başarısızsa tekrar form gösterilir
        }

        // Tüm öğrencileri listeleme işlemi (GET)
        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var students = await _studentService.GetAllStudents(); // Tüm öğrenciler getiriliyor
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students); // Entity'ler DTO'ya çevriliyor
            return View(studentDtos); // DTO'lar view'e gönderiliyor
        }
    }
}