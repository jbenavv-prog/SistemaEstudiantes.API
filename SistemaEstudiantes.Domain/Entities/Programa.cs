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
    public class Programa
    {
        public int IDPrograma { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
