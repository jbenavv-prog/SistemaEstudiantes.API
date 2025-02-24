using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.DTOs;
using AutoMapper;

namespace SistemaEstudiantes.API.Mapping
{
    public class ProgramaProfile : Profile
    {
        public ProgramaProfile()
        {
            CreateMap<Programa, ProgramaResponseDTO>();
            CreateMap<ProgramaResponseDTO, Materia>();
        }
    }
}
