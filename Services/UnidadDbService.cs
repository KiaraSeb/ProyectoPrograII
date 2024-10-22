
public class UnidadDbService : IUnidadService
{
  private readonly BibliotecaContext _context; //define la variable

    public UnidadDbService(BibliotecaContext context)
    {
        _context = context;
    }
    public Unidad Create(UnidadDTO a)
    {
        var NuevoUnidad = new Unidad
        {
          Nombre = a.Nombre
        };

        _context.Unidads.Add(NuevoUnidad);
        _context.SaveChanges();
        return NuevoUnidad;
    }

    public void Delete(int id)
    {
        var Unidad = _context.Unidads.Find(id);
        _context.Unidads.Remove(Unidad);
        _context.SaveChanges();
        
    }

    public IEnumerable<Unidad> GetAll()
    {
      return _context.Unidads;
    }

    public Unidad? GetById(int id)
    {
        Unidad t = _context.Unidads.Find(id);
        return t;
    }

    public Unidad? Update(int id, UnidadDTO a)
    {
        throw new NotImplementedException();
    }
}