public interface IUnidadService
{
    IEnumerable<Unidad> GetAll();
    Unidad? GetById(int id);
    Unidad Create(UnidadDTO unidadDto);
    void Delete(int id);
    Unidad? Update(int id, Unidad unidad);
}
