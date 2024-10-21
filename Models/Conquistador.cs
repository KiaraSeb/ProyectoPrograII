using System.Text.Json.Serialization;
using Microsoft.Identity.Client;

public class Conquistador
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
 // [JsonIgnore]
  //public virtual List<Libro> Libros{get; set;}
  public Conquistador()
  {

  }

  public Conquistador(int id, string nombre, string apellido)
  {
    Id = id;
    Nombre = nombre;
    Apellido = apellido;
  }


  override public string ToString()
  {
    return $"Id:{Id}, {Nombre} {Apellido}";
  }
}