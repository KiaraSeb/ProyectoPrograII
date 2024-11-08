using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/personas")]
public class PersonaController : ControllerBase
{
    private readonly IPersonaService _personaService;

    public PersonaController(IPersonaService personaService)
    {
        _personaService = personaService;
    }

    [HttpGet]
    public ActionResult<List<Persona>> GetAllPersonas()
    {
        return Ok(_personaService.GetAll());
    }

    [HttpGet("{PersonaId}")]
    public ActionResult<Persona> GetById(int PersonaId)
    {
        var persona = _personaService.GetById(PersonaId);
        return persona == null ? NotFound("Persona no encontrada.") : Ok(persona);
    }

    [HttpPost]
    public ActionResult<Persona> NuevaPersona(PersonaDTO personaDto)
    {
        var nuevaPersona = _personaService.Create(personaDto);
        return CreatedAtAction(nameof(GetById), new {PersonaId = nuevaPersona.PersonaId }, nuevaPersona);
    }

    [HttpPut("{personaId}")]
    public IActionResult Update(int personaId, [FromBody] PersonaDTO personaDto)
    {
        if (personaDto == null)
        {
            return BadRequest("El objeto persona no puede ser nulo.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedPersona = _personaService.Update(personaId, personaDto);
        if (updatedPersona == null)
        {
            return NotFound($"Persona con ID {personaId} no encontrada.");
        }

        return Ok(updatedPersona);
    }
    
    [HttpDelete("{PersonaId}")]
    public ActionResult Delete(int PersonaId)
    {
        if (!_personaService.Delete(PersonaId))
            return NotFound("Persona no encontrada.");
        return NoContent();
    }

}
