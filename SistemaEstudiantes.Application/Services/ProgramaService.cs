using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Domain.Interfaces;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Infrastructure.Security;
using System.ComponentModel;

namespace SistemaEstudiantes.Application.Services
{
    public class ProgramaService
    {
        private readonly IProgramaRepository _programaRepository;
        private readonly IMapper _mapper;
  
        public ProgramaService(IProgramaRepository usuarioRepository, IMapper mapper, IProgramaRepository programaRepository)
        {
            _programaRepository = programaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Programa>> GetAllAsync()
        {
            return await _programaRepository.GetAllAsync();
        }

        public async Task<Programa?> GetByIdAsync(int id)
        {
            return await _programaRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Programa programa)
        {
            await _programaRepository.UpdateAsync(programa);
        }

        public async Task DeleteAsync(int id)
        {
            await _programaRepository.DeleteAsync(id);
        }
    }
}
