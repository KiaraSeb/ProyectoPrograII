using System.Text.Json;

public class ClubFileService //: IClubService
{
    private readonly IFileStorageService _fileStorageService;
    private readonly IAutorService _autorService;
    private readonly string _filePath = "Data/Clubs.json";

    public ClubFileService(IFileStorageService fileStorageService, IAutorService autorService)
    {
      _fileStorageService = fileStorageService;
      _autorService = autorService;
    }
    public Club Create(ClubDTO l)
    {
      // List<Club> Clubs = (List<Club>)GetAll();

      // //Encontramos el maximo id existente
      // int lastId = Clubs.Max( l => l.Id);
      // //l.Id = lastId + 1;

      // Clubs.Add(l);
      // var json = JsonSerializer.Serialize(Clubs);
      // _fileStorageService.Write(_filePath , json);
      // return l;
      throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
      List<Club> Clubs = (List<Club>)GetAll();
      Club? ClubParaEliminar =  Clubs.Find( l => l.Id == id);
      
      if( ClubParaEliminar is null ) return false;
      
      bool deleted = Clubs.Remove(ClubParaEliminar) ;
      if ( deleted ) 
      {
        var json = JsonSerializer.Serialize(Clubs);
        _fileStorageService.Write(_filePath , json);
      }
      return deleted;
    }

    public IEnumerable<Club> GetAll()
    {
      var json = _fileStorageService.Read(_filePath);
      return JsonSerializer.Deserialize<List<Club>>(json) ?? new();
    }

    public Club? GetById(int id)
    {      
      List<Club> Clubs = (List<Club>)GetAll();
      return Clubs.Find( l => l.Id == id);
    }

    public Boolean Update(int id, Club l)
    {
      List<Club> Clubs = (List<Club>)GetAll();
      int index = Clubs.FindIndex( li => li.Id == id);
      //No se encontró el id que se quiere actualizar
      if ( index == -1 ) return false;

      // El autor que se quiere cargar existe?
      // bool autorValido = _autorService.ElAutorExiste(l.Autor);
      // if ( autorValido == false ) throw new HttpStatusCodeException("El autor recibido no es válido", 400);
      Clubs[index] = l;
      _fileStorageService.Write(_filePath, JsonSerializer.Serialize(Clubs));
      return true;
    }
}