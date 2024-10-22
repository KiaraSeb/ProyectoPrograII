
using System.Text.Json;

public class ConquistadorFileService
{
    private readonly string _filePath = "Data/Conquistadores.json";
    private readonly IFileStorageService _fileStorageService;

    public ConquistadorFileService(IFileStorageService fileStorageService)
    {
      _fileStorageService = fileStorageService;
    }
    //este método se encarga de de crear un nuevo Conquistadory y le asigna un id siempre maximo
    public Conquistador Create(Conquistador a)
    {
        //Asigno el id al Conquistador nuevo buscando el maximo id en la lista actual de Conquistadores y sumando 1
        //a.Id = GetAll().Max(m => m.Id) + 1;
        // Leer el contenido del archivo JSON
        var json = _fileStorageService.Read(_filePath);
        // Deserializar el JSON en una lista de Conquistadores
        var Conquistadores = JsonSerializer.Deserialize<List<Conquistador>>(json) ?? new List<Conquistador>();
        // Agregar el nuevo Conquistador a la lista
        Conquistadores.Add(a);
        // Serializar la lista actualizada de vuelta a JSON
        json = JsonSerializer.Serialize(Conquistadores);
        // Escribir el JSON actualizado en el archivo
        _fileStorageService.Write(_filePath, json);
        return a;
    }

    public void Delete(int id)
    {
        // Leer el contenido del archivo JSON
        var json = _fileStorageService.Read(_filePath);
        // Deserializar el JSON en una lista de Conquistadores
        var Conquistadores = JsonSerializer.Deserialize<List<Conquistador>>(json) ?? new List<Conquistador>();
        // Buscar el Conquistador por id
        var Conquistador = Conquistadores.Find(Conquistador => Conquistador.Id == id);

        // Si el Conquistador existe, eliminarlo de la lista
        if (Conquistador is not null) 
        {
            Conquistadores.Remove(Conquistador);
            // Serializar la lista actualizada de vuelta a JSON
            json = JsonSerializer.Serialize(Conquistadores);
            // Escribir el JSON actualizado en el archivo
            _fileStorageService.Write(_filePath, json);
        }
    }

    public IEnumerable<Conquistador> GetAll()
    {
        //Leo el contenido del archivo
        var json = _fileStorageService.Read(_filePath);
        //Deserializo el Json en una lista de Conquistadores si es nulo retorna una lista vacia
        return JsonSerializer.Deserialize<List<Conquistador>>(json) ?? new List<Conquistador>();
    }

    public Conquistador GetById(int id)
    {
        //Leo el contenido del archivo
        var json = _fileStorageService.Read(_filePath);
        //Deserializo el Json en una lista de Conquistadores
        List<Conquistador> Conquistadores = JsonSerializer.Deserialize<List<Conquistador>>(json);
        if(Conquistadores is null) return null;
        //Busco el Conquistador por Id y devuelvo el Conquistador encontrado
        return Conquistadores.Find(a => a.Id == id);  

    }

    public Conquistador Update(int id, Conquistador Conquistador)
    {
         // Leer el contenido del archivo JSON
        var json = _fileStorageService.Read(_filePath);
        // Deserializar el JSON en una lista de Conquistadores
        var Conquistadores = JsonSerializer.Deserialize<List<Conquistador>>(json) ?? new List<Conquistador>();
        // Buscar el índice del Conquistador por id
        var ConquistadorIndex = Conquistadores.FindIndex(a => a.Id == id);

        // Si el Conquistador existe, reemplazarlo en la lista
        if (ConquistadorIndex >= 0) 
        {
            //reeplazo el Conquistador de la lista por el Conquistador recibido por parametro con los nuevos datos
            Conquistadores[ConquistadorIndex] = Conquistador;
            // Serializar la lista actualizada de vuelta a JSON
            json = JsonSerializer.Serialize(Conquistadores);
            // Escribir el JSON actualizado en el archivo
            _fileStorageService.Write(_filePath, json);
            return Conquistador;
        }

        // Retornar null si el Conquistador no fue encontrado
        return null;
    }
    
}