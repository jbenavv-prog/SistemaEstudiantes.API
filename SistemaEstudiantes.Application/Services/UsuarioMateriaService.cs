using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Domain.Interfaces;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Infrastructure.Repositories;
using SistemaEstudiantes.Infrastructure.Security;
using System.Linq;

namespace SistemaEstudiantes.Application.Services
{
    public class UsuarioMateriaService
    {
        private readonly IUsuarioMateriaRepository _usuarioMateriaRepository;
        private readonly IMapper _mapper;

        public UsuarioMateriaService(IUsuarioMateriaRepository usuarioMateriaRepository, IMapper mapper)
        {
            _usuarioMateriaRepository = usuarioMateriaRepository;
            _mapper = mapper;
        }

        public async Task<bool> suscribirMateria(CreateUsuarioMateriaDTO createUsuarioMateriaDTO)
        {
            var usuarioMaterias = _mapper.Map<UsuarioMateria>(createUsuarioMateriaDTO);
            await _usuarioMateriaRepository.AddAsync(usuarioMaterias);
            return true;
        }
    }
}
