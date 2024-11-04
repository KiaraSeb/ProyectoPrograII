using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
//[Authorize]
[AllowAnonymous]
[Route("api/especialidades")]
public class EspecialidadController : ControllerBase {

    private readonly IEspecialidadService _especialidadService;

    public EspecialidadController(IEspecialidadService especialidadService)
    {
        _especialidadService = especialidadService;
    }

    [HttpGet]
    public ActionResult<List<Especialidad>> GetAllEspecialidades()
    {
        return Ok(_especialidadService.GetAll());
    }

    [HttpGet("{id:int}")] // Especifica que 'id' es un entero
    public ActionResult<Especialidad> GetById(int id)
    {
        // Llama al servicio para obtener la especialidad por ID
        Especialidad? especialidad = _especialidadService.GetById(id);
        if (especialidad == null)
        {
            return NotFound("Especialidad no encontrada.");
        }

        // Retorna el objeto de especialidad que incluye la Descripcion
        return Ok(especialidad);
}


    [HttpPost]
    public ActionResult<Especialidad> NuevaEspecialidad(EspecialidadDTO especialidadDto)
    {
        Especialidad nuevaEspecialidad = _especialidadService.Create(especialidadDto);
        return CreatedAtAction(nameof(GetById), new { id = nuevaEspecialidad.EspecialidadId }, nuevaEspecialidad); // Cambiado de 'Id' a 'EspecialidadId'
    }

    [HttpDelete("{id:int}")] // Especifica que 'id' es un entero
    public ActionResult Delete(int id)
    {
        var especialidad = _especialidadService.GetById(id);
        if (especialidad == null)
        {
            return NotFound("Especialidad no encontrada.");
        }

        _especialidadService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id:int}")] // Especifica que 'id' es un entero
    public ActionResult<Especialidad> UpdateEspecialidad(int id, Especialidad updatedEspecialidad)
    {
        if (id != updatedEspecialidad.EspecialidadId) // Cambiado de 'Id' a 'EspecialidadId'
        {
            return BadRequest("El ID de la especialidad en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        var especialidad = _especialidadService.Update(id, updatedEspecialidad);
        if (especialidad is null)
        {
            return NotFound();
        }
        return CreatedAtAction(nameof(GetById), new { id = especialidad.EspecialidadId }, especialidad); // Cambiado de 'Id' a 'EspecialidadId'
    }
}
