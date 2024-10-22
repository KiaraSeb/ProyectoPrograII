public interface IConquistadorService
{
  public IEnumerable<Conquistador> GetAll();
  public Conquistador? GetById(int id);
  public Conquistador Create(ConquistadorDTO a);

  public void Delete(int id);
  public Conquistador? Update(int id, Conquistador a);
   public IEnumerable<Club> GetClubs(int id);
}