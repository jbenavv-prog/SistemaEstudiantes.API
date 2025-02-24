using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Domain.Interfaces;
using SistemaEstudiantes.DTOs;
using SistemaEstudiantes.Infrastructure.Security;
using System.Linq;

namespace SistemaEstudiantes.Application.Services
{
    public class MateriaService
    {
        private readonly IMateriaRepository _materiaRepository;
        private readonly IUsuarioMateriaRepository _usuarioMateriaRepository;
        private readonly IProfesorRepository _profesorRepository;
        private readonly IMapper _mapper;

        public MateriaService(IMateriaRepository materiaRepository, IMapper mapper, IUsuarioMateriaRepository usuarioMateriaRepository, IProfesorRepository profesorRepository)
        {
            _materiaRepository = materiaRepository;
            _usuarioMateriaRepository = usuarioMateriaRepository;
            _profesorRepository = profesorRepository;
            
            _mapper = mapper;
        }

        public async Task<List<MateriaValidadaResponseDTO>> GetWithValidations(int idUsuario)
        {
            var listMaterias = new List<MateriaValidadaResponseDTO>();

            // Obtener datos
            var materias = (await _materiaRepository.GetAllAsync()).ToDictionary(m => m.IDMateria);
            var usuariosMateriasSeleccionadas = await _usuarioMateriaRepository.GetByIdUsuarioAsync(idUsuario);
            var profesores = (await _profesorRepository.GetAllAsync()).ToDictionary(p => p.IDProfesor);

            // Materias y profesores ya seleccionados por el usuario
            var listMateriasSeleccionadas = usuariosMateriasSeleccionadas
                .Where(um => materias.ContainsKey(um.IDMateria))
                .Select(um => materias[um.IDMateria])
                .ToList();

            var listProfesoresSeleccionados = listMateriasSeleccionadas
                .Where(m => profesores.ContainsKey(m.IDProfesor))
                .Select(m => profesores[m.IDProfesor])
                .ToHashSet(); // Usar HashSet para búsqueda rápida

            int cantidadMateriasSeleccionadas = listMateriasSeleccionadas.Count;

            foreach (var materia in materias.Values)
            {
                bool esMiembro = listMateriasSeleccionadas.Any(m => m.IDMateria == materia.IDMateria);
                var listaMensajes = new List<string>();
                bool puedeIngresar = true;

                if (!esMiembro)
                {
                    if (cantidadMateriasSeleccionadas >= 3)
                    {
                        listaMensajes.Add("Ya tienes 3 materias seleccionadas.");
                        puedeIngresar = false;
                    }

                    if (listProfesoresSeleccionados.Any(p => p.IDProfesor == materia.IDProfesor))
                    {
                        listaMensajes.Add("No puedes seleccionar otra materia con el mismo profesor.");
                        puedeIngresar = false;
                    }
                }

                listMaterias.Add(new MateriaValidadaResponseDTO
                {
                    Nombre = materia.Nombre,
                    PuedeIngresar = puedeIngresar,
                    EsMiembro = esMiembro,
                    Mensajes = listaMensajes
                });
            }

            return listMaterias;
        }
    }
}
