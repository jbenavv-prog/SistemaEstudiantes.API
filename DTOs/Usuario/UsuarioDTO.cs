using System.ComponentModel.DataAnnotations;

namespace SistemaEstudiantes.DTOs
{
    public class UsuarioDTO
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
