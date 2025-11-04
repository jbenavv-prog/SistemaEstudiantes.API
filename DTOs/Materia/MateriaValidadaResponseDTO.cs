namespace SistemaEstudiantes.DTOs
{
    public class MateriaValidadaResponseDTO
    {
        public int IdMateria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string NombreProfesor { get; set; } = string.Empty;
        public bool PuedeIngresar { get; set; }
        public bool EsMiembro { get; set; }
        public List<string> Mensajes { get; set; } = new List<string>();
    }
}
