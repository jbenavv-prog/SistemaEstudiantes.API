using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Domain.Entities
{
    public class Materia
    {
        public int IDMateria { get; set; }
        public int IDProfesor { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public int Creditos { get; set; }
        public Profesor? Profesor { get; set; }
        public ICollection<UsuarioMateria> UsuarioMaterias { get; set; } = new List<UsuarioMateria>();

    }
}


