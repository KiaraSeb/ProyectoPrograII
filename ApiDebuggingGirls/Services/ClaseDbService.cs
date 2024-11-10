using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ClaseDbService : IClaseService
{
    private readonly BibliotecaContext _context;

    public ClaseDbService(BibliotecaContext context)
    {
        _context = context;
    }

    public List<Clase> GetAll()
    {
        return _context.Clases.ToList();
    }

    public Clase? GetById(int ClaseId)
    {
        return _context.Clases.Find(ClaseId);
    }
}
