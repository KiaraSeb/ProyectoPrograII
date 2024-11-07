using System.ComponentModel.DataAnnotations;

public class EspecialidadDTO
{
    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo Tipo es requerido.")]
    public string? Tipo { get; set; }
}
