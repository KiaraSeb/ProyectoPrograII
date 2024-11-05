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

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetEspecialidadById(int id)
    {
        var especialidad = _especialidadService.GetById(id);
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
        return CreatedAtAction(nameof(GetEspecialidadById), new { id = especialidad.EspecialidadId }, especialidad);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteEspecialidad(int id)
    {
        _especialidadService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateEspecialidad(int id, [FromBody] Especialidad especialidad)
    {
        var updatedEspecialidad = _especialidadService.Update(id, especialidad);
        if (updatedEspecialidad == null)
        {
            return NotFound();
        }
        return Ok(updatedEspecialidad);
    }
}
