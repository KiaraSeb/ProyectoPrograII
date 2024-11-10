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
}
