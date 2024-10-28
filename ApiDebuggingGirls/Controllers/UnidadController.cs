using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/unidades")]
public class UnidadController : ControllerBase {

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
        Unidad? unidad = _unidadService.GetById(id);
        if (unidad == null)
        {
            return NotFound("Unidad no encontrada.");
        }

        return Ok(unidad);
    }

    [HttpPost]
    public ActionResult<Unidad> NuevaUnidad(UnidadDTO unidadDto)
    {
        Unidad nuevaUnidad = _unidadService.Create(unidadDto);
        return CreatedAtAction(nameof(GetById), new { id = nuevaUnidad.Id }, nuevaUnidad);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var unidad = _unidadService.GetById(id);
        if (unidad == null)
        {
            return NotFound("Unidad no encontrada.");
        }

        _unidadService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Unidad> UpdateUnidad(int id, Unidad updatedUnidad)
    {
        if (id != updatedUnidad.Id)
        {
            return BadRequest("El ID de la unidad en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        var unidad = _unidadService.Update(id, updatedUnidad);
        if (unidad is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetById), new { id = unidad.Id }, unidad);
    }
}
