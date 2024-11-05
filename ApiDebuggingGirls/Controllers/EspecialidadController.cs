using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[AllowAnonymous]
[Route("api/especialidades")]
public class EspecialidadController : ControllerBase
{
    private readonly IEspecialidadService _especialidadService;

    public EspecialidadController(IEspecialidadService especialidadService)
    {
        _especialidadService = especialidadService;
    }

    [HttpGet]
    public ActionResult<List<Especialidad>> GetAllEspecialidades()
    {
        return Ok(_especialidadService.GetAll());
    }

    [HttpGet("{especialidadId:int}")] // Cambiado a especialidadId
    public ActionResult<Especialidad> GetById(int especialidadId)
    {
        Especialidad? especialidad = _especialidadService.GetById(especialidadId);
        if (especialidad == null)
        {
            return NotFound("Especialidad no encontrada.");
        }

        return Ok(especialidad);
    }

    [HttpPost]
    public ActionResult<Especialidad> NuevaEspecialidad(EspecialidadDTO especialidadDto)
    {
        Especialidad nuevaEspecialidad = _especialidadService.Create(especialidadDto);
        return CreatedAtAction(nameof(GetById), new { especialidadId = nuevaEspecialidad.EspecialidadId }, nuevaEspecialidad);
    }

    [HttpDelete("{especialidadId}")]
    public ActionResult Delete(int especialidadId) // Cambiado a especialidadId
    {
        var especialidad = _especialidadService.GetById(especialidadId);
        if (especialidad == null)
        {
            return NotFound("Especialidad no encontrada.");
        }

        _especialidadService.Delete(especialidadId);
        return NoContent();
    }

    [HttpPut("{especialidadId}")]
    public ActionResult<Especialidad> UpdateEspecialidad(int especialidadId, Especialidad updatedEspecialidad)
    {
        if (especialidadId != updatedEspecialidad.EspecialidadId)
        {
            return BadRequest("El ID de la especialidad en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        var especialidad = _especialidadService.Update(especialidadId, updatedEspecialidad);
        if (especialidad is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetById), new { especialidadId = especialidad.EspecialidadId }, especialidad);
    }
}
