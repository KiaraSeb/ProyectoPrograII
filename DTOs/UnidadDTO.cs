using System.Collections.Generic;

public class UnidadDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ClaseDTO Clase { get; set; }  // Clase asociada (Amigo, Compañero, etc.)
    
    public PersonaDTO Director { get; set; }  // Director de la unidad
    public List<PersonaDTO> Conquistadores { get; set; }  // Lista de conquistadores en la unidad
    public List<PersonaDTO> Consejeros { get; set; }  // Lista de consejeros en la unidad
}
