
using Microsoft.EntityFrameworkCore;

public class ConquistadorDbService : IConquistadorService
{
  private readonly BibliotecaContext _context;

  public ConquistadorDbService(BibliotecaContext context)
  {
    _context = context;
  }
    public Conquistador Create(ConquistadorDTO a)
    {
        Conquistador Conquistador = new()
        {
            Nombre = a.Nombre,
            Apellido = a.Apellido
        };
        _context.Conquistadores.Add(Conquistador);
       _context.SaveChanges();
       return Conquistador;
    }

    public void Delete(int id)
    {
        var a = _context.Conquistadores.Find(id);
        _context.Conquistadores.Remove(a);
        _context.SaveChanges();
    }

    public IEnumerable<Conquistador> GetAll()
    {
        return _context.Conquistadores; //.Where(a => a.Nombre.Contains("j")) ;
    }

    public Conquistador? GetById(int id)
    {
        return _context.Conquistadores.Find(id);
    }

    public Conquistador? Update(int id, Conquistador a)
    {
        _context.Entry(a).State = EntityState.Modified;
        _context.SaveChanges();
        return a;
    }

    public IEnumerable<Libro> GetClubs(int id)
    {
        Conquistador a = _context.Conquistadores.Include(a => a.Libros).ThenInclude(l => l.Temas).FirstOrDefault(x => x.Id == id);
        return a.Libros;
    }
}
