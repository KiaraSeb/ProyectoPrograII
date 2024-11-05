using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

public class Especialidad
{
    [Column("EspecialidadId")] // Mapea esta propiedad a la columna EspecialidadId en la base de datos
    public int EspecialidadId { get; set; } // Cambiado a EspecialidadId para reflejar la clave primaria

    public string? Nombre { get; set; }

    [Column("Tipo")] // Mapea a la columna Tipo en lugar de Descripcion
    public string? Tipo { get; set; }
    
    [JsonIgnore]
    public virtual List<Persona> Personas { get; set; }

    public Especialidad()
    {
        Personas = new List<Persona>();
    }

    public Especialidad(int especialidadId, string nombre, string tipo)
    {
        EspecialidadId = especialidadId;
        Nombre = nombre;
        Tipo = tipo;
        Personas = new List<Persona>();
    }

    override public string ToString()
    {
        return $"EspecialidadId:{EspecialidadId}, Nombre:{Nombre}, Tipo:{Tipo}";
    }
}
