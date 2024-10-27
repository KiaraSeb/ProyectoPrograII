using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUnidadService
{
    Task<IEnumerable<UnidadDTO>> GetUnidadesAsync();
    Task<UnidadDTO> GetUnidadByIdAsync(int id);
    Task<UnidadDTO> CreateUnidadAsync(UnidadDTO unidad);
    Task<UnidadDTO> UpdateUnidadAsync(UnidadDTO unidad);
    Task<bool> DeleteUnidadAsync(int id);
}
