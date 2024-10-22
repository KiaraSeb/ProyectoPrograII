using System.ComponentModel.DataAnnotations;

public class ConquistadorDTO {
  [Required( ErrorMessage = "El campo Nombre es requerido.")] //decorador, estamos diciendo que este campo debe ser si o si requerido
  public string? Nombre { get; set; }
  [Required( ErrorMessage = "El campo Apellido es requerido.")]
  public string? Apellido { get; set; }
}