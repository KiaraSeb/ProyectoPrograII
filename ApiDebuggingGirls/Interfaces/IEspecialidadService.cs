public interface IEspecialidadService
{
    IEnumerable<Especialidad> GetAll();
    Especialidad? GetById(int EspecialidadId);
    Especialidad Create(EspecialidadDTO especialidadDto);
    void Delete(int EspecialidadId);
    Especialidad? Update(int EspecialidadId, Especialidad especialidad);
}
