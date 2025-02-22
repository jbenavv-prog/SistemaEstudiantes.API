using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Application.Services
{
    public class EstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _estudianteRepository.GetAllAsync();
        }

        public async Task<Estudiante> GetByIdAsync(int id)
        {
            return await _estudianteRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Estudiante estudiante)
        {
            await _estudianteRepository.AddAsync(estudiante);
        }

        public async Task UpdateAsync(Estudiante estudiante)
        {
            await _estudianteRepository.UpdateAsync(estudiante);
        }

        public async Task DeleteAsync(int id)
        {
            await _estudianteRepository.DeleteAsync(id);
        }
    }
}
