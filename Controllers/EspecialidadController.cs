using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class EspecialidadController : ControllerBase
{
    private readonly IEspecialidadService _especialidadService;

    public EspecialidadController(IEspecialidadService especialidadService)
    {
        _especialidadService = especialidadService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EspecialidadDTO>>> GetEspecialidades()
    {
        var especialidades = await _especialidadService.GetEspecialidadesAsync();
        return Ok(especialidades);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EspecialidadDTO>> GetEspecialidad(int id)
    {
        var especialidad = await _especialidadService.GetEspecialidadByIdAsync(id);
        if (especialidad == null) return NotFound();
        return Ok(especialidad);
    }

    [HttpPost]
    public async Task<ActionResult<EspecialidadDTO>> CreateEspecialidad(EspecialidadDTO especialidad)
    {
        var createdEspecialidad = await _especialidadService.CreateEspecialidadAsync(especialidad);
        return CreatedAtAction(nameof(GetEspecialidad), new { id = createdEspecialidad.Id }, createdEspecialidad);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEspecialidad(int id, EspecialidadDTO especialidad)
    {
        if (id != especialidad.Id) return BadRequest();
        await _especialidadService.UpdateEspecialidadAsync(especialidad);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEspecialidad(int id)
    {
        var deleted = await _especialidadService.DeleteEspecialidadAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
