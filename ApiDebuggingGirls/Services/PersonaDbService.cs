using Microsoft.EntityFrameworkCore;

public class PersonaDbService : IPersonaService
{
    private readonly BibliotecaContext _context;

    public PersonaDbService(BibliotecaContext context)
    {
        _context = context;
    }

    public Persona Create(PersonaDTO p)
    {
        Persona persona = new()
        {
            Nombre = p.Nombre,
        };
        _context.Personas.Add(persona);
        _context.SaveChanges();
        return persona;
    }

    public bool Delete(int PersonaId) // Cambiado de void a bool
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

    public Persona? Update(int PersonaId, PersonaDTO p)
    {
        var persona = _context.Personas.Find(PersonaId);
        if (persona == null) return null;

        persona.Nombre = p.Nombre;
        _context.SaveChanges();
        return persona;
    }
}
