using Microsoft.AspNetCore.Authorization; // Para la autorización
using Microsoft.AspNetCore.Mvc; // Para los atributos de controlador
using System.Collections.Generic; // Para List<T>
using YourNamespace.DTOs; // Cambia esto por el espacio de nombres correcto
using YourNamespace.Models; // Cambia esto por el espacio de nombres correcto

[ApiController]
[Authorize]
[Route("api/unidades")]
public class UnidadController : ControllerBase
{
    private readonly IUnidadService _unidadService;

    public UnidadController(IUnidadService unidadService)
    {
        _unidadService = unidadService;
    }

    [HttpGet]
    public ActionResult<List<Unidad>> GetAllUnidades()
    {
        return Ok(_unidadService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Unidad> GetById(int id)
    {
        var unidad = _unidadService.GetById(id);
        if (unidad == null)
        {
            return NotFound("Unidad no encontrada");
        }
        return Ok(unidad);
    }

    [HttpPost] // Este atributo debe estar presente
    public ActionResult<Unidad> NuevoUnidad(UnidadDTO u)
    {
        var unidad = _unidadService.Create(u);
        return CreatedAtAction(nameof(GetById), new { id = unidad.Id }, unidad);
    }

    [HttpPut("{id}")] // Atributo para la actualización
    public ActionResult<Unidad> UpdateUnidad(int id, Unidad updatedUnidad)
    {
        if (id != updatedUnidad.Id)
        {
            return BadRequest("El ID de la unidad en la URL no coincide con el ID de la unidad en el cuerpo de la solicitud.");
        }
        
        var unidad = _unidadService.Update(id, updatedUnidad);
        if (unidad == null)
        {
            return NotFound("Unidad no encontrada");
        }
        return Ok(unidad);
    }

    [HttpDelete("{id}")] // Atributo para la eliminación
    public ActionResult Delete(int id)
    {
        var unidad = _unidadService.GetById(id);
        if (unidad == null)
        {
            return NotFound("Unidad no encontrada");
        }

        _unidadService.Delete(id);
        return NoContent();
    }
}
