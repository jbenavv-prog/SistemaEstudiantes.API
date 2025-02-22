namespace SistemaEstudiantes.DTOs
{
    public class CreateEstudianteDTO
    {
        public string Nombre { get; set; } = String.Empty;
        public int IDEstudiante { get; set; }
        public int IDPrograma { get; set; }
    }
}
