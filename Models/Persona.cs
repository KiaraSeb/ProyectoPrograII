// Models/Persona.cs
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; } // "Líder" o "Conquistador"
    public List<Especialidad> EspecialidadesTerminadas { get; set; } = new List<Especialidad>();
}
