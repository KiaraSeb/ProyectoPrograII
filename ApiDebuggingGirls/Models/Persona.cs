using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Personas")]
public class Persona
{
    public int PersonaId { get; set; }
    public string? Nombre { get; set; }
    public bool EsLider { get; set; }
    public int ClaseId { get; set; }

    [JsonIgnore]
    public virtual Clase? Clase { get; set; }

    // Relación con PersonaEspecialidad
    public virtual List<PersonaEspecialidad> PersonaEspecialidades { get; set; } = new List<PersonaEspecialidad>();
}
