using System.Collections.Generic;

public class PersonaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }    // Nombre de la persona
    public string Apellido { get; set; }  // Apellido de la persona

    // Lista de especialidades terminadas por la persona
    public List<EspecialidadDTO> Especialidades { get; set; }  
}
