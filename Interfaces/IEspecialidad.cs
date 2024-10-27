using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEspecialidadService
{
    Task<IEnumerable<EspecialidadDTO>> GetEspecialidadesAsync();
    Task<EspecialidadDTO> GetEspecialidadByIdAsync(int id);
    Task<EspecialidadDTO> CreateEspecialidadAsync(EspecialidadDTO especialidad);
    Task<EspecialidadDTO> UpdateEspecialidadAsync(EspecialidadDTO especialidad);
    Task<bool> DeleteEspecialidadAsync(int id);
}
