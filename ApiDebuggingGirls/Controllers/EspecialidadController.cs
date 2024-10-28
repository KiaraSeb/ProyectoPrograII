using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/especialidades")]
public class EspecialidadController : ControllerBase {

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

    [HttpGet("{id}")]
    public ActionResult<Especialidad> GetById(int id)
    {
        Especialidad? especialidad = _especialidadService.GetById(id);
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
        return CreatedAtAction(nameof(GetById), new { id = nuevaEspecialidad.Id }, nuevaEspecialidad);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var especialidad = _especialidadService.GetById(id);
        if (especialidad == null)
        {
            return NotFound("Especialidad no encontrada.");
        }

        _especialidadService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Especialidad> UpdateEspecialidad(int id, Especialidad updatedEspecialidad)
    {
        if (id != updatedEspecialidad.Id)
        {
            return BadRequest("El ID de la especialidad en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        var especialidad = _especialidadService.Update(id, updatedEspecialidad);
        if (especialidad is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetById), new { id = especialidad.Id }, especialidad);
    }
}
