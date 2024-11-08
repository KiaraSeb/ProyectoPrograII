using System.ComponentModel.DataAnnotations.Schema;

public class PersonaEspecialidad
{
    public int PersonaId { get; set; }
    public Persona Persona { get; set; }

    public int EspecialidadId { get; set; }
    public Especialidad Especialidad { get; set; }
}
