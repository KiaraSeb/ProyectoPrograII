using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/clases")]
public class ClaseController : ControllerBase {

    private readonly IClaseService _claseService;

    public ClaseController(IClaseService claseService)
    {
        _claseService = claseService;
    }

    [HttpGet]
    public ActionResult<List<Clase>> GetAllClases()
    {
        return Ok(_claseService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Clase> GetById(int id)
    {
        Clase? clase = _claseService.GetById(id);
        if (clase == null)
        {
            return NotFound("Clase no encontrada.");
        }

        return Ok(clase);
    }

    [HttpPost]
    public ActionResult<Clase> NuevaClase(ClaseDTO claseDto)
    {
        Clase nuevaClase = _claseService.Create(claseDto);
        return CreatedAtAction(nameof(GetById), new { id = nuevaClase.Id }, nuevaClase);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var clase = _claseService.GetById(id);
        if (clase == null)
        {
            return NotFound("Clase no encontrada.");
        }

        _claseService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Clase> UpdateClase(int id, Clase updatedClase)
    {
        if (id != updatedClase.Id)
        {
            return BadRequest("El ID de la clase en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        var clase = _claseService.Update(id, updatedClase);
        if (clase is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetById), new { id = clase.Id }, clase);
    }
}
