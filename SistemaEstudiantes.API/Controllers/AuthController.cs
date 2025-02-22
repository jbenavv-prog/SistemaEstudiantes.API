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
            var user = await _usuarioService.LoginAsync(loginUsuarioDTO);
            if (user == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos.");
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUsuarioDTO createUsuarioDTO)
        {
            await _usuarioService.AddAsync(createUsuarioDTO);
            return Ok("Usuario creado exitosamente.");
        }
    }
}
