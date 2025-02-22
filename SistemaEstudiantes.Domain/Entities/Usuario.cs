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
    [Index(nameof(Email), IsUnique = true)] // Índice único en la propiedad Email
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }

        [Required]
        [ForeignKey("Estudiantes")]
        public int IDEstudiante { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$",
            ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una minúscula, un número y un carácter especial.")]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string Contrasena { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
