using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IPasswordHasher<Usuario> passwordHasher, IJwtProvider jwtProvider)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateEstudianteDTO createEstudianteDTO)
        {
            var estudiante = _mapper.Map<Usuario>(createEstudianteDTO);
            await _usuarioRepository.AddAsync(estudiante);
        }

        public async Task UpdateAsync(Usuario estudiante)
        {
            await _usuarioRepository.UpdateAsync(estudiante);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
