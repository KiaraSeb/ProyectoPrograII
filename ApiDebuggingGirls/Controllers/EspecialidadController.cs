using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var especialidades = _especialidadService.GetAll();
        return Ok(especialidades);
    }

    [HttpGet("{EspecialidadId}")]
    [Authorize]
    public IActionResult GetEspecialidadById(int EspecialidadId)
    {
        var especialidad = _especialidadService.GetById(EspecialidadId);
        if (especialidad == null)
        {
            return NotFound();
        }
        return Ok(especialidad);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateEspecialidad([FromBody] EspecialidadDTO especialidadDto)
    {
        var especialidad = _especialidadService.Create(especialidadDto);
        return CreatedAtAction(nameof(GetEspecialidadById), new { EspecialidadId = especialidad.EspecialidadId }, especialidad);
    }

    [HttpDelete("{EspecialidadId}")]
    [Authorize]
    public IActionResult DeleteEspecialidad(int EspecialidadId)
    {
        _especialidadService.Delete(EspecialidadId);
        return NoContent();
    }

    [HttpPut("{EspecialidadId}")]
    [Authorize]
    public IActionResult UpdateEspecialidad(int EspecialidadId, [FromBody] Especialidad especialidad)
    {
        var updatedEspecialidad = _especialidadService.Update(EspecialidadId, especialidad);
        if (updatedEspecialidad == null)
        {
            return NotFound();
        }
        return Ok(updatedEspecialidad);
    }
}
