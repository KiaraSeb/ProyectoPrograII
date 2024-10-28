using System.Text.Json.Serialization;

public class Persona
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }

    public Persona()
    {
    }

    public Persona(int id, string nombre, string apellido, string email)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
    }

    override public string ToString()
    {
        return $"Id:{Id}, {Nombre} {Apellido}, Email:{Email}";
    }
}
