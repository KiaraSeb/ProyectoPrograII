using System.Text.Json.Serialization;

public class Clase
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    
    [JsonIgnore]
    public virtual List<Unidad> Unidades { get; set; }

    public Clase()
    {
        Unidades = new List<Unidad>();
    }

    public Clase(int id, string nombre, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Unidades = new List<Unidad>();
    }

    override public string ToString()
    {
        return $"Id:{Id}, Nombre:{Nombre}, Descripción:{Descripcion}";
    }
}
