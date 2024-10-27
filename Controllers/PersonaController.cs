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
    public ActionResult<List<PersonaDTO>> GetAllPersonas()
    {
        return Ok(_personaService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<PersonaDTO> GetById(int id)
    {
        var persona = _personaService.GetById(id);
        if (persona == null)
        {
            return NotFound("Persona no encontrada.");
        }

        return Ok(persona);
    }

    [HttpPost]
    public ActionResult<PersonaDTO> CrearPersona(PersonaDTO personaDto)
    {
        var persona = _personaService.Create(personaDto);
        return CreatedAtAction(nameof(GetById), new { id = persona.Id }, persona);
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
    public ActionResult<PersonaDTO> UpdatePersona(int id, PersonaDTO updatedPersonaDto)
    {
        if (id != updatedPersonaDto.Id)
        {
            return BadRequest("El ID de la persona en la URL no coincide con el ID de la persona en el cuerpo de la solicitud.");
        }

        var persona = _personaService.Update(id, updatedPersonaDto);
        if (persona == null)
        {
            return NotFound("Persona no encontrada.");
        }

        return CreatedAtAction(nameof(GetById), new { id = persona.Id }, persona);
    }
}
