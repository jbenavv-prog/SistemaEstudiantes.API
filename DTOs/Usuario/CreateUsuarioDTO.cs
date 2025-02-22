namespace SistemaEstudiantes.DTOs
{
    public class CreateUsuarioDTO
    {
        public string Nombre { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Contrasena { get; set; } = String.Empty;
        public int IDPrograma { get; set; }
    }
}
