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
            Clase = u.Clase, // Asegúrate de que la propiedad Clase sea del tipo adecuado
            Director = u.Director, // Debes asegurarte de que la propiedad Director sea del tipo adecuado
            Conquistadores = u.Conquistadores, // Asegúrate de que este tipo sea compatible
            Consejeros = u.Consejeros // Asegúrate de que este tipo sea compatible
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
        return _context.Unidades.Include(u => u.Director).Include(u => u.Conquistadores).Include(u => u.Consejeros);
    }

    public Unidad? GetById(int id)
    {
        return _context.Unidades.Include(u => u.Director).Include(u => u.Conquistadores).Include(u => u.Consejeros).FirstOrDefault(u => u.Id == id);
    }

    public Unidad? Update(int id, Unidad u)
    {
        _context.Entry(u).State = EntityState.Modified;
        _context.SaveChanges();
        return u;
    }
}
