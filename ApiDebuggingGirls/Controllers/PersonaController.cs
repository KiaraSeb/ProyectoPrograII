using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Authorize]
[Route("api/personas")]
public class PersonaController : ControllerBase
{
    private readonly IPersonaService _personaService;
    private readonly IEspecialidadService _especialidadService; // Inyección del servicio de especialidad.

    public PersonaController(IPersonaService personaService, IEspecialidadService especialidadService)
    {
        _personaService = personaService;
        _especialidadService = especialidadService; // Asignación del servicio de especialidad.
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
        return CreatedAtAction(nameof(GetById), new { PersonaId = nuevaPersona.PersonaId }, nuevaPersona);
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

        var persona = _personaService.GetById(personaId);
        if (persona == null)
        {
            return NotFound($"Persona con ID {personaId} no encontrada.");
        }

        persona.PersonaEspecialidades.Clear();

        foreach (var especialidadId in personaDto.EspecialidadIds)
        {
            var especialidad = _especialidadService.GetById(especialidadId);
            if (especialidad != null)
            {
                persona.PersonaEspecialidades.Add(new PersonaEspecialidad
                {
                    PersonaId = persona.PersonaId,
                    EspecialidadId = especialidad.EspecialidadId
                });
            }
        }

        _personaService.Save(); // Verifica que este método esté implementado.

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
