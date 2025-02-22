namespace SistemaEstudiantes.DTOs
{
    public class UpdateEstudianteDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public int IDPrograma { get; set; }
    }
}
