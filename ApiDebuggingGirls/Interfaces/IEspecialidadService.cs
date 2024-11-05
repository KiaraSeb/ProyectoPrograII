public interface IEspecialidadService
{
    IEnumerable<Especialidad> GetAll();
    Especialidad? GetById(int especialidadId);
    Especialidad Create(EspecialidadDTO especialidadDto);
    void Delete(int especialidadId);
    Especialidad? Update(int especialidadId, Especialidad especialidad);
}
