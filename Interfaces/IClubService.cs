public interface IClubService
{
  public IEnumerable<Club> GetAll();
  public Club? GetById(int id);
  public Club Create(ClubDTO l);

  public bool Delete(int id);
  public Club Update(int id, ClubDTO l);
}