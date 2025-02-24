using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.DTOs;
using AutoMapper;

namespace SistemaEstudiantes.API.Mapping
{
    public class MateriaProfile : Profile
    {
        public MateriaProfile()
        {
            CreateMap<Materia, MateriaValidadaResponseDTO>();
            CreateMap<MateriaValidadaResponseDTO, Materia>();
        }
    }
}
