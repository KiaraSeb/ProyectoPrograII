using System.ComponentModel.DataAnnotations;

public class PersonaDTO
{
    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo EsLider es requerido.")]
    public bool EsLider { get; set; }

    [Required(ErrorMessage = "El campo ClaseId es requerido.")]
    public int ClaseId { get; set; }
}
