namespace SistemaEstudiantes.DTOs
{
    public class CreateUsuarioDTO
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int IDPrograma { get; set; }
    }
}
