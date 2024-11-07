using System.Text.Json.Serialization;

public class Clase
{
    public int ClaseId { get; set; }
    public string? Nombre { get; set; }
    
    [JsonIgnore]
    public virtual List<Unidad> Unidades { get; set; }

    public Clase()
    {
        Unidades = new List<Unidad>();
    }

    public Clase(int ClaseId, string nombre)
    {
        ClaseId = ClaseId;
        Nombre = nombre;
        Unidades = new List<Unidad>();
    }

    override public string ToString()
    {
        return $"ClaseId:{ClaseId}, Nombre:{Nombre}";
    }
}
