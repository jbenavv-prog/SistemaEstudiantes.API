using AutoMapper;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Domain.Interfaces;
using SistemaEstudiantes.DTOs;
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
        private readonly IMapper _mapper;
        public EstudianteService(IEstudianteRepository estudianteRepository, IMapper mapper)
        {
            _estudianteRepository = estudianteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _estudianteRepository.GetAllAsync();
        }

        public async Task<Estudiante> GetByIdAsync(int id)
        {
            return await _estudianteRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateEstudianteDTO createEstudianteDTO)
        {
            var estudiante = _mapper.Map<Estudiante>(createEstudianteDTO);
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
