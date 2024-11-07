using System.Text.Json.Serialization;

public class Unidad
{
    public int UnidadId { get; set; }
    public string? Nombre { get; set; }
    
    // Clave foránea hacia Clase
    public int ClaseId { get; set; }

    // Propiedad de navegación para la relación con Clase
    public Clase Clase { get; set; } 

    public Unidad()
    {
        // Constructor vacío
    }

    public Unidad(int unidadId, string nombre, int claseId)
    {
        UnidadId = unidadId;
        Nombre = nombre;
        ClaseId = claseId;
    }

    public override string ToString()
    {
        return $"UnidadId:{UnidadId}, Nombre:{Nombre}, ClaseId:{ClaseId}";
    }
}
