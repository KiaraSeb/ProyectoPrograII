public interface IEspecialidadService
{
    IEnumerable<Especialidad> GetAll();
    Especialidad? GetById(int id);
    Especialidad Create(EspecialidadDTO especialidadDto);
    void Delete(int id);
    Especialidad? Update(int id, Especialidad especialidad);
}
