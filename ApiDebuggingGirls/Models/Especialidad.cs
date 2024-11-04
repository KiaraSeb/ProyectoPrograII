using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Especialidad
{
    public int EspecialidadId { get; set; }  // Asegúrate de que el nombre coincide con la base de datos
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; } // Esta propiedad debe existir para reflejar la base de datos

    [JsonIgnore]
    public virtual List<Persona> Personas { get; set; }

    public Especialidad()
    {
        Personas = new List<Persona>();
    }

    public Especialidad(int id, string nombre, string descripcion)
    {
        EspecialidadId = id; // Cambiado a EspecialidadId
        Nombre = nombre;
        Descripcion = descripcion;
        Personas = new List<Persona>();
    }

    public override string ToString()
    {
        return $"Id: {EspecialidadId}, Nombre: {Nombre}, Descripción: {Descripcion}";
    }
}
