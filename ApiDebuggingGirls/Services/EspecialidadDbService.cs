using Microsoft.EntityFrameworkCore;

public class EspecialidadDbService : IEspecialidadService
{
    private readonly BibliotecaContext _dbContext;

    public EspecialidadDbService(BibliotecaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Especialidad> GetAll()
    {
        return _dbContext.Especialidades.ToList();
    }

    public Especialidad? GetById(int especialidadId) // Cambiado a especialidadId
    {
        return _dbContext.Especialidades
            .FirstOrDefault(e => e.EspecialidadId == especialidadId);
    }

    public Especialidad Create(EspecialidadDTO especialidadDto)
    {
        var nuevaEspecialidad = new Especialidad
        {
            Nombre = especialidadDto.Nombre,
            Tipo = especialidadDto.Tipo
        };
        _dbContext.Especialidades.Add(nuevaEspecialidad);
        _dbContext.SaveChanges();
        return nuevaEspecialidad;
    }

    public void Delete(int especialidadId) // Cambiado a especialidadId
    {
        var especialidad = _dbContext.Especialidades.Find(especialidadId);
        if (especialidad != null)
        {
            _dbContext.Especialidades.Remove(especialidad);
            _dbContext.SaveChanges();
        }
    }

    public Especialidad? Update(int especialidadId, Especialidad especialidad) // Cambiado a especialidadId
    {
        if (especialidadId != especialidad.EspecialidadId) return null;

        _dbContext.Entry(especialidad).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return especialidad;
    }
}
