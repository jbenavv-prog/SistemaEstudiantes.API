using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.DTOs;
using AutoMapper;

namespace SistemaEstudiantes.API.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, LoginUsuarioDTO>();
            CreateMap<Usuario, CreateUsuarioDTO>();
            CreateMap<LoginUsuarioDTO, Usuario>();
            CreateMap<CreateUsuarioDTO, Usuario>();
            CreateMap<Usuario, MateriaValidadaResponseDTO>();
            CreateMap<MateriaValidadaResponseDTO, Usuario>();
        }
    }
}
