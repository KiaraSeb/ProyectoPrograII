using System.Text.Json.Serialization;

public class Persona
{
    public int PersonaId { get; set; }
    public string? Nombre { get; set; }
    public bool EsLider { get; set; } // Propiedad EsLider

    // Clave foránea
    public int ClaseId { get; set; }

    // Propiedad de navegación hacia la clase
    [JsonIgnore]  
    public virtual Clase? Clase { get; set; }

    public Persona() { }

    public Persona(int PersonaId, string nombre,  int claseId, bool esLider)
    {
        PersonaId = PersonaId;
        Nombre = nombre;
        ClaseId = claseId;
        EsLider = esLider;
    }

    override public string ToString()
    {
        return $"PersonaId:{PersonaId}, {Nombre}, EsLider:{EsLider}, ClaseId:{ClaseId}";
    }
}
