using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Application.Services;
using SistemaEstudiantes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SistemaEstudiantes.API.Controllers
{
    [ApiController]
    [Route("api/programa")]
    public class ProgramaController : ControllerBase
    {
        private readonly ProgramaService _programaService;
        public ProgramaController(ProgramaService programaService)
        {
            _programaService = programaService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _programaService.GetAllAsync();
                return Ok(new { message = "Datos obtenidos", data = response });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpPost("getById")]
        public async Task<IActionResult> GetById(int IDPrograma)
        {
            try
            {
                var response = await _programaService.GetByIdAsync(IDPrograma);
                if (response == null)
                    return Ok(new { message = "No se encontraron programas" });
                return Ok(new { message = "Datos obtenidos", data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
    