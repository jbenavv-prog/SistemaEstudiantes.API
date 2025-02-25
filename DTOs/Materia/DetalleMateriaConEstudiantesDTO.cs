namespace SistemaEstudiantes.DTOs
{
    public class DetalleMateriaConEstudiantesResponseDTO
    {
        public int IdMateria { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public List<UsuarioDTO> Estudiantes { get; set; } = new List<UsuarioDTO>();

    }
}
