using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PersonaController : ControllerBase
{
    private readonly IPersonaService _personaService;

    public PersonaController(IPersonaService personaService)
    {
        _personaService = personaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetPersonas()
    {
        var personas = await _personaService.GetPersonasAsync();
        return Ok(personas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonaDTO>> GetPersona(int id)
    {
        var persona = await _personaService.GetPersonaByIdAsync(id);
        if (persona == null) return NotFound();
        return Ok(persona);
    }

    [HttpPost]
    public async Task<ActionResult<PersonaDTO>> CreatePersona(PersonaDTO persona)
    {
        var createdPersona = await _personaService.CreatePersonaAsync(persona);
        return CreatedAtAction(nameof(GetPersona), new { id = createdPersona.Id }, createdPersona);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersona(int id, PersonaDTO persona)
    {
        if (id != persona.Id) return BadRequest();
        await _personaService.UpdatePersonaAsync(persona);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersona(int id)
    {
        var deleted = await _personaService.DeletePersonaAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
