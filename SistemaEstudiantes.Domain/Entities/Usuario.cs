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
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Contrasena { get; set; } = String.Empty;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int IDPrograma { get; set; }
    }
}
