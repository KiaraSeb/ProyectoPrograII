using System.Text.Json.Serialization;

public class Unidad
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    
    [JsonIgnore]
    public virtual List<Clase> Clases { get; set; }

    public Unidad()
    {
        Clases = new List<Clase>();
    }

    public Unidad(int id, string nombre, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Clases = new List<Clase>();
    }

    override public string ToString()
    {
        return $"Id:{Id}, Nombre:{Nombre}, Descripción:{Descripcion}";
    }
}
