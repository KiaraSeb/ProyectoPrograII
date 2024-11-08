using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

public class Especialidad
{
    public int EspecialidadId { get; set; }
    public string? Nombre { get; set; }
    public string? Tipo { get; set; }

    // Relación con PersonaEspecialidad
    public virtual List<PersonaEspecialidad> PersonaEspecialidades { get; set; } = new List<PersonaEspecialidad>();
}
