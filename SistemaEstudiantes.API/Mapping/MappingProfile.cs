using AutoMapper;
using SistemaEstudiantes.DTOs.Estudiante;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.API.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Estudiante, EstudianteDTO>();
            CreateMap<Estudiante, CreateEstudianteDTO>();
            CreateMap<Estudiante, UpdateEstudianteDTO>();
            CreateMap<EstudianteDTO, Estudiante>();
            CreateMap<CreateEstudianteDTO, Estudiante>();
            CreateMap<UpdateEstudianteDTO, Estudiante>();
        }
    }
}
