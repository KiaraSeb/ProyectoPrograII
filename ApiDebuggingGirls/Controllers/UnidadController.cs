using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<Unidad> UpdateUnidad(int UnidadId, UnidadDTO updatedUnidad)
    {
        var unidad = _unidadService.Update(UnidadId, updatedUnidad);
        return unidad == null ? NotFound() : CreatedAtAction(nameof(GetById), new { UnidadId = unidad.UnidadId }, unidad);
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


