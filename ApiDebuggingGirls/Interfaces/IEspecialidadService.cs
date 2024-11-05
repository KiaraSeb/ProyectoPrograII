public interface IEspecialidadService
{
    IEnumerable<Especialidad> GetAll();
    Especialidad? GetById(int especialidadId); // Cambiado a especialidadId
    Especialidad Create(EspecialidadDTO especialidadDto);
    void Delete(int especialidadId); // Cambiado a especialidadId
    Especialidad? Update(int especialidadId, Especialidad especialidad); // Cambiado a especialidadId
}
