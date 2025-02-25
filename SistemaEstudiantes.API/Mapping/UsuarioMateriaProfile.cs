using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.DTOs;
using AutoMapper;

namespace SistemaEstudiantes.API.Mapping
{
    public class UsuarioMateriaProfile : Profile
    {
        public UsuarioMateriaProfile()
        {
            CreateMap<UsuarioMateria, UsuarioMateriaResponseDTO>();
            CreateMap<UsuarioMateriaResponseDTO, UsuarioMateria>();
            CreateMap<CreateUsuarioMateriaDTO, UsuarioMateria>();
            CreateMap<UsuarioMateria, CreateUsuarioMateriaDTO>();
            CreateMap<UsuarioMateria, UsuarioMateriaDTO>();
            CreateMap<UsuarioMateriaDTO, UsuarioMateria>();
        }
    }
}
