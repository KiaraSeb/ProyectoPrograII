using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class PersonaDTO
{
    [Required(ErrorMessage = "El campo Nombre es requerido.")]
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo EsLider es requerido.")]
    public bool EsLider { get; set; }

    [Required(ErrorMessage = "El campo ClaseId es requerido.")]
    public int ClaseId { get; set; }

    // Lista de IDs de especialidades
    public List<int> EspecialidadIds { get; set; } = new List<int>();
}