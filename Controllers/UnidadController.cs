using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UnidadController : ControllerBase
{
    private readonly IUnidadService _unidadService;

    public UnidadController(IUnidadService unidadService)
    {
        _unidadService = unidadService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnidadDTO>>> GetUnidades()
    {
        var unidades = await _unidadService.GetUnidadesAsync();
        return Ok(unidades);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UnidadDTO>> GetUnidad(int id)
    {
        var unidad = await _unidadService.GetUnidadByIdAsync(id);
        if (unidad == null) return NotFound();
        return Ok(unidad);
    }

    [HttpPost]
    public async Task<ActionResult<UnidadDTO>> CreateUnidad(UnidadDTO unidad)
    {
        var createdUnidad = await _unidadService.CreateUnidadAsync(unidad);
        return CreatedAtAction(nameof(GetUnidad), new { id = createdUnidad.Id }, createdUnidad);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUnidad(int id, UnidadDTO unidad)
    {
        if (id != unidad.Id) return BadRequest();
        await _unidadService.UpdateUnidadAsync(unidad);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUnidad(int id)
    {
        var deleted = await _unidadService.DeleteUnidadAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
