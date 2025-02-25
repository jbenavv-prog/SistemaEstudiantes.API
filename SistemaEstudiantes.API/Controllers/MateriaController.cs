using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.Application.Services;
using SistemaEstudiantes.DTOs;

namespace SistemaEstudiantes.API.Controllers
{
    [ApiController]
    [Route("api/materia")]
    public class MateriaController : ControllerBase
    {
        private readonly MateriaService _materiaService;
        public MateriaController(MateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpPost("getWithValidations")]
        public async Task<IActionResult> GetWithValidations(UsuarioDTO usuarioDTO)
        {
            try
            {
                var response = await _materiaService.GetWithValidations(usuarioDTO.IDUsuario);
                return Ok(new { message = "Datos obtenidos", data = response });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
    