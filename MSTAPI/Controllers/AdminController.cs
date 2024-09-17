using Microsoft.AspNetCore.Mvc;
using MSTService;
using MSTAPI.Models;  // Modeli buraya ekleyin

[Route("api/admin")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AdminLoginModel loginModel)
    {
        var admin = await _adminService.GetAdminByLogin(loginModel.LoginName); 
        if (admin != null && admin.Password == loginModel.Password)
        {
            return Ok(new { Token = "dummy-token" }); 
        }
        return Unauthorized();
    }
}
