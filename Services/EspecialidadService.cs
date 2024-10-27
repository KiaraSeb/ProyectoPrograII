using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class EspecialidadService : IEspecialidadService
    {
        private readonly ConquistadoresContext _context;

        public EspecialidadService(ConquistadoresContext context)
        {
            _context = context;
        }

        // Obtener todas las especialidades
        public async Task<IEnumerable<Especialidad>> GetEspecialidadesAsync()
        {
            return await _context.Especialidades.ToListAsync();
        }

        // Obtener una especialidad por Id
        public async Task<Especialidad> GetEspecialidadByIdAsync(int id)
        {
            return await _context.Especialidades.FindAsync(id);
        }

        // Crear una nueva especialidad
        public async Task<Especialidad> CreateEspecialidadAsync(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();
            return especialidad;
        }

        // Actualizar una especialidad
        public async Task<Especialidad> UpdateEspecialidadAsync(Especialidad especialidad)
        {
            _context.Entry(especialidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return especialidad;
        }

        // Eliminar una especialidad
        public async Task<bool> DeleteEspecialidadAsync(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);
            if (especialidad == null)
            {
                return false;
            }

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }

