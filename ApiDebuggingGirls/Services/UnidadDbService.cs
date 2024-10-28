using Microsoft.EntityFrameworkCore;

public class UnidadDbService : IUnidadService
{
    private readonly BibliotecaContext _context;

    public UnidadDbService(BibliotecaContext context)
    {
        _context = context;
    }

    public Unidad Create(UnidadDTO u)
    {
        Unidad unidad = new()
        {
            Nombre = u.Nombre,
            Descripcion = u.Descripcion
        };
        _context.Unidades.Add(unidad);
        _context.SaveChanges();
        return unidad;
    }

    public void Delete(int id)
    {
        var u = _context.Unidades.Find(id);
        if (u != null)
        {
            _context.Unidades.Remove(u);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Unidad> GetAll()
    {
        return _context.Unidades;
    }

    public Unidad? GetById(int id)
    {
        return _context.Unidades.Find(id);
    }

    public Unidad? Update(int id, Unidad u)
    {
        _context.Entry(u).State = EntityState.Modified;
        _context.SaveChanges();
        return u;
    }
}
