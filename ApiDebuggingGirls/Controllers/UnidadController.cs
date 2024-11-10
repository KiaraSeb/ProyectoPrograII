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
    public ActionResult<List<Unidad>> GetAllUnidades()
    {
        return Ok(_unidadService.GetAll());
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
