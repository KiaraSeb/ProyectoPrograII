using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Personas")]
public class Persona
{
    public int PersonaId { get; set; }
    public string? Nombre { get; set; }
    public bool EsLider { get; set; }

    public int UnidadId { get; set; }

    [JsonIgnore]
    public virtual Unidad? Unidad { get; set; } // Relación con la unidad
}
