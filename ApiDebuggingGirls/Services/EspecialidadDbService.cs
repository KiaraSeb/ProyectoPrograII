using Microsoft.EntityFrameworkCore;

public class EspecialidadDbService : IEspecialidadService
{
    private readonly BibliotecaContext _context;

    public EspecialidadDbService(BibliotecaContext context)
    {
        _context = context;
    }

    public IEnumerable<Especialidad> GetAll()
    {
        return _context.Especialidades; // Asegúrate de que `Especialidades` es el DbSet correspondiente en `BibliotecaContext`
    }

    public Especialidad? GetById(int id)
    {
        return _context.Especialidades.Find(id); // Busca por ID en la tabla de especialidades
    }

    public Especialidad Create(EspecialidadDTO especialidadDto)
    {
        Especialidad especialidad = new Especialidad
        {
            Nombre = especialidadDto.Nombre,
            Descripcion = especialidadDto.Descripcion
        };

        _context.Especialidades.Add(especialidad);
        _context.SaveChanges();
        return especialidad;
    }

    public void Delete(int id)
    {
        var especialidad = _context.Especialidades.Find(id);
        if (especialidad != null)
        {
            _context.Especialidades.Remove(especialidad);
            _context.SaveChanges();
        }
    }

    public Especialidad? Update(int id, Especialidad especialidad)
    {
        var existingEspecialidad = _context.Especialidades.Find(id);
        if (existingEspecialidad == null)
        {
            return null;
        }

        // Actualiza las propiedades que corresponden
        existingEspecialidad.Nombre = especialidad.Nombre;
        existingEspecialidad.Descripcion = especialidad.Descripcion;

        _context.Entry(existingEspecialidad).State = EntityState.Modified;
        _context.SaveChanges();
        return existingEspecialidad;
    }
}
