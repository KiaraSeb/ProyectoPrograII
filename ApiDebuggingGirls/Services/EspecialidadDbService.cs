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

    public Especialidad? GetById(int EspecialidadId) 
    {
        return _dbContext.Especialidades
            .FirstOrDefault(e => e.EspecialidadId == EspecialidadId);
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

    public void Delete(int EspecialidadId) 
    {
        var especialidad = _dbContext.Especialidades.Find(EspecialidadId);
        if (especialidad != null)
        {
            _dbContext.Especialidades.Remove(especialidad);
            _dbContext.SaveChanges();
        }
    }

    public Especialidad? Update(int EspecialidadId, Especialidad especialidad) 
    {
        if (EspecialidadId != especialidad.EspecialidadId) return null;

        _dbContext.Entry(especialidad).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return especialidad;
    }
}
