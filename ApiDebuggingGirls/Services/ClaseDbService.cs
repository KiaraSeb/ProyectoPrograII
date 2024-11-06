using Microsoft.EntityFrameworkCore;

public class ClaseDbService : IClaseService
{
    private readonly BibliotecaContext _context;

    public ClaseDbService(BibliotecaContext context)
    {
        _context = context;
    }

    public Clase Create(ClaseDTO c)
    {
        Clase clase = new()
        {
            Nombre = c.Nombre,
            Descripcion = c.Descripcion
        };
        _context.Clases.Add(clase);
        _context.SaveChanges();
        return clase;
    }

    public void Delete(int id)
    {
        var c = _context.Clases.Find(id);
        if (c != null)
        {
            _context.Clases.Remove(c);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Clase> GetAll()
    {
        return _context.Clases;
    }

    public Clase? GetById(int id)
    {
        return _context.Clases.Find(id);
    }

    public Clase? Update(int id, Clase c)
    {
        var existingClase = _context.Clases.Find(id);
        if (existingClase == null)
        {
            return null;
        }

        existingClase.Nombre = c.Nombre;
        existingClase.Descripcion = c.Descripcion;
        _context.SaveChanges();
        return existingClase;
    }

}
