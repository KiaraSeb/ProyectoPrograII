using Microsoft.EntityFrameworkCore;

public class EspecialidadDbService : IEspecialidadService
{
    private readonly BibliotecaContext _dbContext; // Asegúrate de reemplazar `YourDbContext` con el nombre real de tu DbContext

    public EspecialidadDbService(BibliotecaContext dbContext)
    {
        _dbContext = dbContext; // Inicializa el contexto de la base de datos
    }

    public IEnumerable<Especialidad> GetAll()
    {
        return _dbContext.Especialidades.ToList(); // Obtiene todas las especialidades
    }

    public Especialidad? GetById(int id)
    {
        return _dbContext.Especialidades
            .FirstOrDefault(e => e.EspecialidadId == id); // Busca la especialidad por ID
    }

    public Especialidad Create(EspecialidadDTO especialidadDto)
    {
        var nuevaEspecialidad = new Especialidad
        {
            Nombre = especialidadDto.Nombre,
            Descripcion = especialidadDto.Descripcion
        };
        _dbContext.Especialidades.Add(nuevaEspecialidad);
        _dbContext.SaveChanges();
        return nuevaEspecialidad;
    }

    public void Delete(int id)
    {
        var especialidad = _dbContext.Especialidades.Find(id);
        if (especialidad != null)
        {
            _dbContext.Especialidades.Remove(especialidad);
            _dbContext.SaveChanges();
        }
    }

    public Especialidad? Update(int id, Especialidad especialidad)
    {
        if (id != especialidad.EspecialidadId) return null;

        _dbContext.Entry(especialidad).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return especialidad;
    }
}
