namespace SistemaEstudiantes.DTOs
{
    public class LoginResponseUsuarioDTO
    {
        public string Token { get; set; } = string.Empty;
        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
