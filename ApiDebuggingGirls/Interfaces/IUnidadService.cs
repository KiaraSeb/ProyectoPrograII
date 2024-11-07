public interface IUnidadService
{
    IEnumerable<Unidad> GetAll();
    Unidad? GetById(int UnidadId);
    Unidad Create(UnidadDTO unidadDto);
    bool Delete(int UnidadId); // Cambiar a bool
    Unidad? Update(int UnidadId, UnidadDTO unidadDto);
}
