using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Application.Services;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.API.Controllers
{
    [ApiController]
    [Route("api/usuarioMateria")]
    public class UsuarioMateriaController : ControllerBase
    {
        private readonly UsuarioMateriaService _usuarioMateriaService;
        public UsuarioMateriaController(UsuarioMateriaService usuarioMateriaService)
        {
            _usuarioMateriaService = usuarioMateriaService;
        }

        [HttpPost("suscribirMateria")]
        public async Task<IActionResult> SuscribirMateria(CreateUsuarioMateriaDTO createUsuarioMateriaDTO)
        {
            try
            {
                var isSuccess = await _usuarioMateriaService.suscribirMateria(createUsuarioMateriaDTO);
                if(isSuccess)
                    return Ok(new { message = "Materia suscrita exitosamente", Ok = isSuccess });
                return BadRequest(new { message = "Falla con la suscripción de la materia" });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
    