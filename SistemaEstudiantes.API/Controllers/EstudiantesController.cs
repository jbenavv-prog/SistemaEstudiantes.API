using Microsoft.AspNetCore.Mvc;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Application.Services;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly EstudianteService _estudianteService;
        public EstudiantesController(EstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEstudianteDTO createEstudianteDTO) {
            await _estudianteService.AddAsync(createEstudianteDTO);
            return Ok("Estudiante creado exitosamente.");
        }

    }
}
