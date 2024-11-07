using System.ComponentModel.DataAnnotations;

public class UnidadDTO
{
    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    public string? Nombre { get; set; }
     public int ClaseId { get; set; } // El ID de la clase asociada

}
