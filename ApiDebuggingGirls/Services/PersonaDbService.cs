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
    var unidad = _context.Unidades.Find(personaDto.UnidadId);
    if (unidad == null)
    {
        throw new ArgumentException("La unidad especificada no existe.");
    }

    var persona = new Persona
    {
        Nombre = personaDto.Nombre,
        EsLider = personaDto.EsLider,
        UnidadId = personaDto.UnidadId // Asociamos la persona a la unidad
    };

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
    var persona = _context.Personas.FirstOrDefault(p => p.PersonaId == personaId);

    if (persona == null)
    {
        return null; // O lanzar una excepción
    }

    // Actualizar propiedades
    persona.Nombre = personaDto.Nombre;
    persona.EsLider = personaDto.EsLider;
    persona.UnidadId = personaDto.UnidadId;

    _context.SaveChanges();
    return persona;
}


    // Implementación del método Save
    public void Save()
    {
        _context.SaveChanges();
    }
}
