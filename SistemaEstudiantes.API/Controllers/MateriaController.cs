using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Application.Services;
using SistemaEstudiantes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
    