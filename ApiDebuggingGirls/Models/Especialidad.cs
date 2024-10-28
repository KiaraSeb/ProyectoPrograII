using System.Text.Json.Serialization;

public class Especialidad
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    
    [JsonIgnore]
    public virtual List<Persona> Personas { get; set; }

    public Especialidad()
    {
        Personas = new List<Persona>();
    }

    public Especialidad(int id, string nombre, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Personas = new List<Persona>();
    }

    override public string ToString()
    {
        return $"Id:{Id}, Nombre:{Nombre}, Descripción:{Descripcion}";
    }
}
