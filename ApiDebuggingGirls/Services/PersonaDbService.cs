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
            Apellido = p.Apellido,
            Email = p.Email
        };
        _context.Personas.Add(persona);
        _context.SaveChanges();
        return persona;
    }

    public void Delete(int id)
    {
        var p = _context.Personas.Find(id);
        if (p != null)
        {
            _context.Personas.Remove(p);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Persona> GetAll()
    {
        return _context.Personas;
    }

    public Persona? GetById(int id)
    {
        return _context.Personas.Find(id);
    }

    public Persona? Update(int id, Persona p)
    {
        _context.Entry(p).State = EntityState.Modified;
        _context.SaveChanges();
        return p;
    }
}
