using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        };
        _context.Clases.Add(clase);
        _context.SaveChanges();
        return clase;
    }

    public bool Delete(int ClaseId)
    {
        var c = _context.Clases.Find(ClaseId);
        if (c != null)
        {
            _context.Clases.Remove(c);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public List<Clase> GetAll()
    {
        return _context.Clases.ToList();
    }

    public Clase? GetById(int ClaseId)
    {
        return _context.Clases.Find(ClaseId);
    }

    public Clase? Update(int ClaseId, ClaseDTO c)
    {
        var existingClase = _context.Clases.Find(ClaseId);
        if (existingClase == null)
        {
            return null;
        }

        existingClase.Nombre = c.Nombre;
        _context.SaveChanges();
        return existingClase;
    }
}
