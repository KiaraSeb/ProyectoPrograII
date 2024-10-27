using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class ClaseService : IClaseService
    {
        private readonly ConquistadoresContext _context;

        public ClaseService(ConquistadoresContext context)
        {
            _context = context;
        }

        // Obtener todas las clases
        public async Task<IEnumerable<Unidad>> GetClasesAsync()
        {
            return await _context.Unidades.ToListAsync();
        }

        // Obtener una clase por Id
        public async Task<Unidad> GetClaseByIdAsync(int id)
        {
            return await _context.Unidades.FindAsync(id);
        }

        // Crear una nueva clase
        public async Task<Unidad> CreateClaseAsync(Unidad unidad)
        {
            _context.Unidades.Add(unidad);
            await _context.SaveChangesAsync();
            return unidad;
        }

        // Actualizar una clase
        public async Task<Unidad> UpdateClaseAsync(Unidad unidad)
        {
            _context.Entry(unidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return unidad;
        }

        // Eliminar una clase
        public async Task<bool> DeleteClaseAsync(int id)
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

