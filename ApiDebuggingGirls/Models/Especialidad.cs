using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

public class Especialidad
{
    public int EspecialidadId { get; set; } 

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }
    
    [JsonIgnore]
    public virtual List<Persona> Personas { get; set; }

    public Especialidad()
    {
        Personas = new List<Persona>();
    }

    public Especialidad(int EspecialidadId, string nombre, string tipo)
    {
        EspecialidadId = EspecialidadId;
        Nombre = nombre;
        Tipo = tipo;
        Personas = new List<Persona>();
    }

    override public string ToString()
    {
        return $"EspecialidadId:{EspecialidadId}, Nombre:{Nombre}, Tipo:{Tipo}";
    }
}
