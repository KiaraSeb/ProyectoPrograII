using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Authorize]
[Route("api/unidades")]
public class UnidadController : ControllerBase
{
    private readonly BibliotecaContext _context;
    private readonly IUnidadService _unidadService;

    // Constructor único que recibe ambas dependencias
    public UnidadController(BibliotecaContext context, IUnidadService unidadService)
    {
        _context = context;
        _unidadService = unidadService;
    }

    [HttpGet]
public ActionResult<List<object>> GetAllUnidades()
{
    var unidades = _unidadService.GetAll();  // Recuperamos todas las unidades

    if (unidades == null || !unidades.Any())
    {
        return NotFound("No hay unidades registradas.");
    }

    var resultado = unidades.Select(unidad => new
    {
        UnidadId = unidad.UnidadId,
        Nombre = unidad.Nombre,
        ClaseId = unidad.ClaseId,
        ClaseNombre = unidad.Clase?.Nombre // Solo el nombre de la clase, sin personas
    }).ToList();

    return Ok(resultado);  // Regresamos las unidades con sus clases, sin personas
}

[HttpGet("con-personas")]
public ActionResult<List<object>> GetUnidadesConPersonas()
{
    var unidades = _unidadService.GetAll();  // Recuperamos todas las unidades

    if (unidades == null || !unidades.Any())
    {
        return NotFound("No hay unidades registradas.");
    }

    var resultado = unidades.Select(unidad => new
    {
        UnidadId = unidad.UnidadId,
        Nombre = unidad.Nombre,
        ClaseId = unidad.ClaseId,
        ClaseNombre = unidad.Clase?.Nombre, // Solo el nombre de la clase
        Lideres = unidad.Lideres,           // Aquí incluyen los líderes
        Conquistadores = unidad.Conquistadores  // Aquí incluyen los conquistadores
    }).ToList();

    return Ok(resultado);  // Regresamos las unidades con sus personas
}



    [HttpGet("{UnidadId}")]
    public ActionResult<Unidad> GetById(int UnidadId)
    {
        var unidad = _unidadService.GetById(UnidadId);
        return unidad == null ? NotFound("Unidad no encontrada.") : Ok(unidad);
    }

    [HttpPost]
    public ActionResult<Unidad> NuevaUnidad(UnidadDTO unidadDto)
    {
        var nuevaUnidad = _unidadService.Create(unidadDto);
        return CreatedAtAction(nameof(GetById), new { UnidadId = nuevaUnidad.UnidadId }, nuevaUnidad);
    }

    [HttpPut("{UnidadId}")]
    public Unidad? Update(int UnidadId, UnidadDTO updatedUnidadDto)
    {
        var existingUnidad = _context.Unidades.Include(u => u.Clase).FirstOrDefault(u => u.UnidadId == UnidadId);
        if (existingUnidad == null)
        {
            return null; // Unidad no encontrada
        }

        // Asignar los valores desde el DTO
        existingUnidad.Nombre = updatedUnidadDto.Nombre;
        existingUnidad.ClaseId = updatedUnidadDto.ClaseId;

        _context.SaveChanges();
        return existingUnidad; // La unidad devuelta ya incluirá la clase asociada
    }

    [HttpDelete("{UnidadId}")]
    public ActionResult Delete(int UnidadId)
    {
        if (!_unidadService.Delete(UnidadId))
        {
            return NotFound("Unidad no encontrada.");
        }
        return NoContent();
    }
}
