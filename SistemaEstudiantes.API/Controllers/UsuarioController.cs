using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Application.Services;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.API.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("suscribirPrograma")]
        public async Task<IActionResult> SuscribirPrograma(SuscripcionProgramaUsuarioDTO suscripcionProgramaUsuarioDTO)
        {
            await _usuarioService.UpdateAsync(suscripcionProgramaUsuarioDTO);
            return Ok(new { message = "Usuario creado exitosamente." });
        }
    }
}
    