using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.Application.Services;

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
        public async Task<IActionResult> GetWithValidations(int idUsuario)
        {
            try
            {
                var response = await _materiaService.GetWithValidations(idUsuario);
                return Ok(new { message = "Datos obtenidos", data = response });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
    