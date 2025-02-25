using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Application.Services;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public AuthController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            try
            {
                var response = await _usuarioService.LoginAsync(loginUsuarioDTO);
                return Ok(new { message = "Ingreso de usuario exitoso", data = response });
            }
            catch (Exception ex) 
            {
                return Unauthorized(new { message = ex.Message});
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUsuarioDTO createUsuarioDTO)
        {
            try
            {
                await _usuarioService.RegisterAsync(createUsuarioDTO);
                return Ok(new { message = "Usuario creado exitosamente." });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
    