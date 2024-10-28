using System.ComponentModel.DataAnnotations;

public class UnidadDTO
{
    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo Descripción es requerido.")]
    public string? Descripcion { get; set; }
}
