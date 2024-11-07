using Microsoft.EntityFrameworkCore;

public class UnidadDbService : IUnidadService
{
    private readonly BibliotecaContext _context;

    public UnidadDbService(BibliotecaContext context)
    {
        _context = context;
    }

    // Crear una nueva Unidad
    public Unidad Create(UnidadDTO u)
    {
        // Verificar si la ClaseId proporcionada existe
        var clase = _context.Clases.Find(u.ClaseId);
        if (clase == null)
        {
            throw new ArgumentException("La Clase especificada no existe.");
        }

        Unidad unidad = new()
        {
            Nombre = u.Nombre,
            ClaseId = u.ClaseId // Asignar el ClaseId relacionado
        };

        _context.Unidades.Add(unidad);
        _context.SaveChanges();
        return unidad;
    }

    // Eliminar una Unidad
    public bool Delete(int UnidadId)
    {
        var unidad = _context.Unidades.Find(UnidadId);
        if (unidad == null)
        {
            return false; // Si no se encuentra la unidad, devolver false
        }

        _context.Unidades.Remove(unidad);
        _context.SaveChanges();
        return true; // Si se eliminó correctamente, devolver true
    }


    // Obtener todas las Unidades, incluyendo las clases asociadas
    public IEnumerable<Unidad> GetAll()
    {
        return _context.Unidades.Include(u => u.Clase).ToList(); // Cargar también la Clase asociada
    }

    // Obtener una Unidad por su ID, incluyendo la Clase asociada
    public Unidad? GetById(int UnidadId)
    {
        return _context.Unidades.Include(u => u.Clase).FirstOrDefault(u => u.UnidadId == UnidadId); // Cargar la Clase asociada
    }

    // Actualizar una Unidad
    public Unidad? Update(int UnidadId, UnidadDTO updatedUnidadDto)
    {
        var existingUnidad = _context.Unidades.Find(UnidadId);
        if (existingUnidad == null)
        {
            return null; // Unidad no encontrada
        }

        // Asignar los valores desde el DTO
        existingUnidad.Nombre = updatedUnidadDto.Nombre;
        existingUnidad.ClaseId = updatedUnidadDto.ClaseId;

        _context.SaveChanges();
        return existingUnidad;
    }

}
