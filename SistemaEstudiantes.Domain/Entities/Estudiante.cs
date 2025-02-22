using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Domain.Entities
{
    public class Estudiante
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IDPrograma { get; set; }
    }
}
