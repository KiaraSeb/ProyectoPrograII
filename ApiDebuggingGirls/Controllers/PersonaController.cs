using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Authorize]
[Route("api/personas")]
public class PersonaController : ControllerBase
{
    private readonly IPersonaService _personaService;

    public PersonaController(IPersonaService personaService)
    {
        _personaService = personaService ?? throw new ArgumentNullException(nameof(personaService));
    }

    [HttpGet]
    public ActionResult<List<Persona>> GetAllPersonas()
    {
        try
        {
            var personas = _personaService.GetAll();

            if (personas == null || personas.Count() == 0)
            {
                return NotFound("No hay personas registradas.");
            }

            return Ok(personas);
        }
        catch (Exception ex)
        {
            // Aquí puedes registrar el error para un mejor análisis
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

    [HttpGet("{PersonaId}")]
    public ActionResult<Persona> GetById(int PersonaId)
    {
        try
        {
            var persona = _personaService.GetById(PersonaId);

            if (persona == null)
            {
                return NotFound("Persona no encontrada.");
            }

            return Ok(persona);
        }
        catch (Exception ex)
        {
            // Registrar error
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Persona> NuevaPersona([FromBody] PersonaDTO personaDto)
    {
        if (personaDto == null)
        {
            return BadRequest("El objeto persona no puede ser nulo.");
        }

        try
        {
            var nuevaPersona = _personaService.Create(personaDto);
            return CreatedAtAction(nameof(GetById), new { PersonaId = nuevaPersona.PersonaId }, nuevaPersona);
        }
        catch (Exception ex)
        {
            // Registrar error
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
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

        try
        {
            var updatedPersona = _personaService.Update(personaId, personaDto);
            if (updatedPersona == null)
            {
                return NotFound($"Persona con ID {personaId} no encontrada.");
            }

            _personaService.Save(); // Verifica que este método esté implementado en tu servicio.

            return Ok(updatedPersona);
        }
        catch (Exception ex)
        {
            // Registrar error
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

    [HttpDelete("{PersonaId}")]
    public ActionResult Delete(int PersonaId)
    {
        try
        {
            var success = _personaService.Delete(PersonaId);

            if (!success)
            {
                return NotFound("Persona no encontrada.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            // Registrar error
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }
}
