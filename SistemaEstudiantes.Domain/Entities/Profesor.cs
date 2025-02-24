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
    public class Profesor
    {
        public int IDProfesor { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public ICollection<Materia> Materias { get; set; } = new List<Materia>();
    }
}
