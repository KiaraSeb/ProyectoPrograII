public class Unidad
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Clase { get; set; }
    
    public List<Persona> Conquistadores { get; set; } = new List<Persona>();
    public List<Persona> Consejeros { get; set; } = new List<Persona>();
}