using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Especialidad
{
    public int EspecialidadId { get; set; }
    public string? Nombre { get; set; }
    public string? Tipo { get; set; }
}
