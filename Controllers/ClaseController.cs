using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ClaseController : ControllerBase
{
    private readonly IClaseService _claseService;

    public ClaseController(IClaseService claseService)
    {
        _claseService = claseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClaseDTO>>> GetClases()
    {
        var clases = await _claseService.GetClasesAsync();
        return Ok(clases);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClaseDTO>> GetClase(int id)
    {
        var clase = await _claseService.GetClaseByIdAsync(id);
        if (clase == null) return NotFound();
        return Ok(clase);
    }

    [HttpPost]
    public async Task<ActionResult<ClaseDTO>> CreateClase(ClaseDTO clase)
    {
        var createdClase = await _claseService.CreateClaseAsync(clase);
        return CreatedAtAction(nameof(GetClase), new { id = createdClase.Id }, createdClase);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClase(int id, ClaseDTO clase)
    {
        if (id != clase.Id) return BadRequest();
        await _claseService.UpdateClaseAsync(clase);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClase(int id)
    {
        var deleted = await _claseService.DeleteClaseAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
