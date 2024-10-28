public interface IClaseService
{
    IEnumerable<Clase> GetAll();
    Clase? GetById(int id);
    Clase Create(ClaseDTO claseDto);
    void Delete(int id);
    Clase? Update(int id, Clase clase);
}
