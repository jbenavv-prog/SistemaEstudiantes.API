using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Domain.Interfaces;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Infrastructure.Security;

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

        public async Task<bool> RegisterAsync(CreateUsuarioDTO createUsuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(createUsuarioDTO);
            usuario.Contrasena = _passwordHasher.HashPassword(usuario, createUsuarioDTO.Contrasena);
            await _usuarioRepository.AddAsync(usuario);
            return true;
        }

        public async Task<LoginResponseUsuarioDTO> LoginAsync(LoginUsuarioDTO loginUsuarioDTO) {
            var usuario = await _usuarioRepository.GetByEmailAsync(loginUsuarioDTO.Email);
            if (usuario == null) {
                throw new Exception("Usuario no encontrado");
            }
            var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Contrasena, loginUsuarioDTO.Contrasena);
            if (result == PasswordVerificationResult.Failed) {
                throw new Exception("Credenciales incorrectas");
            }
            var token =  _jwtProvider.GenerateToken(usuario.IDUsuario.ToString());

            return new LoginResponseUsuarioDTO
            {
                Token = token,
                IDUsuario = usuario.IDUsuario,
                Nombre = usuario.Nombre,
                Email = usuario.Email
            };
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateUsuarioDTO createUsuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(createUsuarioDTO);
            await _usuarioRepository.AddAsync(usuario);
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
