using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ServiceOrdersManagement.Application.DTOs;
using ServiceOrdersManagement.Application.Interfaces;

namespace ServiceOrdersManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var tokenDto = _authService.Login(loginDto);
                return Ok(tokenDto);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
