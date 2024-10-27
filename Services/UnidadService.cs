using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class UnidadService : IUnidadService
    {
        private readonly ConquistadoresContext _context;

        public UnidadService(ConquistadoresContext context)
        {
            _context = context;
        }

        // Obtener todas las unidades
        public async Task<IEnumerable<Unidad>> GetUnidadesAsync()
        {
            return await _context.Unidades.Include(u => u.Conquistadores)
                                          .Include(u => u.Consejeros)
                                          .Include(u => u.Director)
                                          .ToListAsync();
        }

        // Obtener una unidad por Id
        public async Task<Unidad> GetUnidadByIdAsync(int id)
        {
            return await _context.Unidades.Include(u => u.Conquistadores)
                                          .Include(u => u.Consejeros)
                                          .Include(u => u.Director)
                                          .FirstOrDefaultAsync(u => u.Id == id);
        }

        // Crear una nueva unidad
        public async Task<Unidad> CreateUnidadAsync(Unidad unidad)
        {
            _context.Unidades.Add(unidad);
            await _context.SaveChangesAsync();
            return unidad;
        }

        // Actualizar una unidad
        public async Task<Unidad> UpdateUnidadAsync(Unidad unidad)
        {
            _context.Entry(unidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return unidad;
        }

        // Eliminar una unidad
        public async Task<bool> DeleteUnidadAsync(int id)
        {
            var unidad = await _context.Unidades.FindAsync(id);
            if (unidad == null)
            {
                return false;
            }

            _context.Unidades.Remove(unidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }

