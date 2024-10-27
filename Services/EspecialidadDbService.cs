using Microsoft.EntityFrameworkCore;

public class EspecialidadDbService : IEspecialidadService
{
    private readonly BibliotecaContext _context;

    public EspecialidadDbService(BibliotecaContext context)
    {
        _context = context;
    }

    public Especialidad Create(EspecialidadDTO e)
    {
        Especialidad especialidad = new()
        {
            Nombre = e.Nombre,
            Descripcion = e.Descripcion
        };
        _context.Especialidades.Add(especialidad);
        _context.SaveChanges();
        return especialidad;
    }

    public void Delete(int id)
    {
        var e = _context.Especialidades.Find(id);
        if (e != null)
        {
            _context.Especialidades.Remove(e);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Especialidad> GetAll()
    {
        return _context.Especialidades;
    }

    public Especialidad? GetById(int id)
    {
        return _context.Especialidades.Find(id);
    }

    public Especialidad? Update(int id, Especialidad e)
    {
        _context.Entry(e).State = EntityState.Modified;
        _context.SaveChanges();
        return e;
    }
}
