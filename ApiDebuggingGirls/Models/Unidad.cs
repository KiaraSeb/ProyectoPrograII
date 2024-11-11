using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public class Unidad
{
    public int UnidadId { get; set; }
    public string? Nombre { get; set; }

    // Clave foránea hacia Clase
    public int ClaseId { get; set; }

    // Relación con la Clase
    public Clase Clase { get; set; }

    // Listas de personas asociadas a la unidad
    public virtual List<Persona> Personas { get; set; } = new List<Persona>();

    [NotMapped]  // Evita que EF Core lo mapee
    public virtual List<Persona> Lideres
    {
        get
        {
            return Personas.Where(p => p.EsLider).ToList(); // Filtramos los lideres
        }
    }

    [NotMapped]  // Evita que EF Core lo mapee
    public virtual List<Persona> Conquistadores
    {
        get
        {
            return Personas.Where(p => !p.EsLider).ToList(); // Filtramos los conquistadores
        }
    }
}
