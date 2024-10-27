using System.Collections.Generic;
using System.Threading.Tasks;

public interface IClaseService
{
    Task<IEnumerable<ClaseDTO>> GetClasesAsync();
    Task<ClaseDTO> GetClaseByIdAsync(int id);
    Task<ClaseDTO> CreateClaseAsync(ClaseDTO clase);
    Task<ClaseDTO> UpdateClaseAsync(ClaseDTO clase);
    Task<bool> DeleteClaseAsync(int id);
}
