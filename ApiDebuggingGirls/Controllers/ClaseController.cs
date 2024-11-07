using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/clases")]
public class ClaseController : ControllerBase
{
    private readonly IClaseService _claseService;

    public ClaseController(IClaseService claseService)
    {
        _claseService = claseService;
    }

    [HttpGet]
    public ActionResult<List<Clase>> GetAll()
    {
        try
        {
            return Ok(_claseService.GetAll());
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return Problem(detail: e.Message, statusCode: 500);
        }
    }

    [HttpGet("{ClaseId}")]
    public ActionResult<Clase> GetById(int ClaseId)
    {
        Clase? clase = _claseService.GetById(ClaseId);
        if (clase is null) return NotFound();
        return Ok(clase);
    }

    [HttpPost]
    public ActionResult<Clase> NuevaClase(ClaseDTO c)
    {
        Clase clase = _claseService.Create(c);
        return CreatedAtAction(nameof(GetById), new { ClaseId = clase.ClaseId }, clase);
    }

    [HttpPut("{ClaseId}")]
    public ActionResult<Clase> Update(int ClaseId, ClaseDTO c)
    {
        try
        {
            Clase clase = _claseService.Update(ClaseId, c);
            if (clase is null) return NotFound(new { Message = $"No se pudo actualizar la clase con ClaseId: {ClaseId}" });
            return CreatedAtAction(nameof(GetById), new { ClaseId = clase.ClaseId }, clase);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return Problem(detail: e.Message, statusCode: 500);
        }
    }

    [HttpDelete("{ClaseId}")]
    public ActionResult Delete(int ClaseId)
    {
        bool deleted = _claseService.Delete(ClaseId);
        if (deleted) return NoContent();
        return NotFound();
    }

}
