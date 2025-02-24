namespace SistemaEstudiantes.DTOs
{
    public class ProgramaSuscritoResponseDTO
    {
        public int IDPrograma { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Boolean EsMiembro { get; set; }
    }
}
