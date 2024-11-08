using Microsoft.EntityFrameworkCore;

public class PersonaDbService : IPersonaService
{
    private readonly BibliotecaContext _context;

    public PersonaDbService(BibliotecaContext context)
    {
        _context = context;
    }

    public Persona Create(PersonaDTO personaDto)
{
    // Crea la persona
    Persona persona = new()
    {
        Nombre = personaDto.Nombre,
        EsLider = personaDto.EsLider,
        ClaseId = personaDto.ClaseId
    };

    // Asociar las especialidades
    foreach (var especialidadId in personaDto.EspecialidadIds)
    {
        var especialidad = _context.Especialidades.Find(especialidadId);
        if (especialidad != null)
        {
            persona.PersonaEspecialidades.Add(new PersonaEspecialidad
            {
                Persona = persona,
                Especialidad = especialidad
            });
        }
    }

    _context.Personas.Add(persona);
    _context.SaveChanges();
    return persona;
}


    public bool Delete(int PersonaId)
    {
        var persona = _context.Personas.Find(PersonaId);
        if (persona == null) return false;

        _context.Personas.Remove(persona);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<Persona> GetAll()
    {
        return _context.Personas;
    }

    public Persona? GetById(int PersonaId)
    {
        return _context.Personas.Find(PersonaId);
    }

    public Persona Update(int personaId, PersonaDTO personaDto)
    {
        var persona = _context.Personas.Include(p => p.PersonaEspecialidades)
                                        .ThenInclude(pe => pe.Especialidad)
                                        .FirstOrDefault(p => p.PersonaId == personaId);

        if (persona == null)
        {
            return null; // O lanzar una excepción
        }

        // Actualizar propiedades
        persona.Nombre = personaDto.Nombre;
        persona.EsLider = personaDto.EsLider;
        persona.ClaseId = personaDto.ClaseId;

        // Limpiar las especialidades existentes
        persona.PersonaEspecialidades.Clear();

        // Agregar las nuevas especialidades
        foreach (var especialidadId in personaDto.EspecialidadIds)
        {
            persona.PersonaEspecialidades.Add(new PersonaEspecialidad
            {
                PersonaId = persona.PersonaId,
                EspecialidadId = especialidadId
            });
        }

        _context.SaveChanges();
        return persona;
    }

    public Persona? UpdateEspecialidades(int personaId, List<int> especialidadIds)
    {
        var persona = _context.Personas
            .Include(p => p.PersonaEspecialidades)
            .FirstOrDefault(p => p.PersonaId == personaId);

        if (persona == null) return null;

        // Elimina las asociaciones existentes
        persona.PersonaEspecialidades.Clear();

        // Agrega las nuevas asociaciones
        foreach (var especialidadId in especialidadIds)
        {
            var especialidad = _context.Especialidades.Find(especialidadId);
            if (especialidad != null)
            {
                persona.PersonaEspecialidades.Add(new PersonaEspecialidad
                {
                    Persona = persona,
                    Especialidad = especialidad
                });
            }
        }

        _context.SaveChanges();

        // Retorna la persona actualizada con los IDs de las especialidades vinculadas
        return persona;
    }


}
