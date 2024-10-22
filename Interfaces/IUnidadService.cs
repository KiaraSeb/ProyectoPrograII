public interface IUnidadService
{
  public IEnumerable<Unidad> GetAll();
  public Unidad? GetById(int id);
  public Unidad Create(UnidadDTO a);

  public void Delete(int id);
  public Unidad? Update(int id, UnidadDTO a);
}