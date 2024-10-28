using System.ComponentModel.DataAnnotations;

public class PersonaDTO
{
    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es requerido.")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "El campo Email es requerido.")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
    public string? Email { get; set; }
}
