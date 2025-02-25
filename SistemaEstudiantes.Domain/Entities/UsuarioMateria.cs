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
    public class UsuarioMateria
    {
        public int IDUsuarioMateria { get; set; }
        public int IDUsuario{ get; set; }
        public int IDMateria { get; set; }
        public Usuario? Usuario { get; set; }
        public Materia? Materia { get; set; }
    }
}
