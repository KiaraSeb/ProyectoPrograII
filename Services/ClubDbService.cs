
using Microsoft.EntityFrameworkCore;

public class ClubDbService : IClubService
{
    private readonly BibliotecaContext _context;

    public ClubDbService(BibliotecaContext context)
    {
        _context = context;
    }
    public Club Create(ClubDTO l)
    {
        var nuevoClub = new Club
        {
            Titulo = l.Titulo,
            AutorId = l.AutorId,
            Miembros = l.Miembros,
            Ano = l.Ano,
            Unidad = new List<Unidad>()
        };

        foreach(int idUnidad in l.UnidadIds)
        {
            nuevoClub.Unidad.Add(_context.Unidad.Find(idUnidad));
        }
        _context.Add(nuevoClub);
        _context.SaveChanges();
        return nuevoClub;
    }

    public bool Delete(int id)
    {
        Club? l = _context.Clubs.Find(id);
        if (l is null) return false;

        _context.Clubs.Remove(l);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<Club> GetAll()
    {
        return _context.Clubs.Include(el => el.Autor).Include(l => l.Unidad);
    }

    public Club? GetById(int id)
    {
        return _context.Clubs.Find(id);
    }

    public Club Update(int id, ClubDTO l)
    {
        var ClubUpdate = _context.Clubs.Include(l => l.Unidad).FirstOrDefault(l => l.Id == id);
        Console.WriteLine(ClubUpdate.Id);
        ClubUpdate.Titulo = l.Titulo;
        ClubUpdate.Ano = l.Ano;
        ClubUpdate.Miembros = l.Miembros;
        ClubUpdate.AutorId = l.AutorId;
        ClubUpdate.Url_Portada = l.Url_Portada;
        ClubUpdate.Unidad.Clear();

        
        foreach(int idUnidad in l.UnidadIds)
        {
            ClubUpdate.Unidad.Add(_context.Unidad.Find(idUnidad));
        }

        _context.Entry(ClubUpdate).State = EntityState.Modified;
        _context.SaveChanges();
        return ClubUpdate;

    }
}