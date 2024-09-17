using Microsoft.AspNetCore.Mvc;
using MSTService;

namespace MSTMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ShowNavbar = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string loginName, string password)
        {
            var admin = await _adminService.GetAdminByLogin(loginName);
            if (admin != null && admin.Password == password)
            {
                return Redirect("/Student/AddStudent");

            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre.";
                return View();
            }
        }
    }
}