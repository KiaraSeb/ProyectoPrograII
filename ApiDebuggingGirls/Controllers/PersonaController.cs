using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/personas")]
public class PersonaController : ControllerBase {

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

    [HttpGet("{id}")]
    public ActionResult<Persona> GetById(int id)
    {
        Persona? persona = _personaService.GetById(id);
        if (persona == null)
        {
            return NotFound("Persona no encontrada.");
        }

        return Ok(persona);
    }

    [HttpPost]
    public ActionResult<Persona> NuevaPersona(PersonaDTO personaDto)
    {
        Persona nuevaPersona = _personaService.Create(personaDto);
        return CreatedAtAction(nameof(GetById), new { id = nuevaPersona.Id }, nuevaPersona);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var persona = _personaService.GetById(id);
        if (persona == null)
        {
            return NotFound("Persona no encontrada.");
        }

        _personaService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Persona> UpdatePersona(int id, Persona updatedPersona)
    {
        if (id != updatedPersona.Id)
        {
            return BadRequest("El ID de la persona en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        var persona = _personaService.Update(id, updatedPersona);
        if (persona is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetById), new { id = persona.Id }, persona);
    }
}
