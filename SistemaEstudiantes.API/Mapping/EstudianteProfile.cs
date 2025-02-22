using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.DTOs;
using AutoMapper;

namespace SistemaEstudiantes.API.Mapping
{
    public class EstudianteProfile: Profile
    {
        public EstudianteProfile()
        {
            CreateMap<Estudiante, EstudianteDTO>();
            CreateMap<Estudiante, CreateUsuarioDTO>();
            CreateMap<Estudiante, UpdateEstudianteDTO>();
            CreateMap<EstudianteDTO, Estudiante>();
            CreateMap<CreateUsuarioDTO, Estudiante>();
            CreateMap<UpdateEstudianteDTO, Estudiante>();
            CreateMap<UpdateEstudianteDTO, Estudiante>();
        }
    }
}
