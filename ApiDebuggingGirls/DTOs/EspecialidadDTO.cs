using System.ComponentModel.DataAnnotations;

public class EspecialidadDTO
{
    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo Descripción es requerido.")]
    public string? Tipo { get; set; }
}
