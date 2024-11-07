using System.Collections.Generic;

public interface IClaseService
{
    List<Clase> GetAll();
    Clase GetById(int ClaseId);
    Clase Create(ClaseDTO claseDto);
    Clase Update(int ClaseId, ClaseDTO claseDto);
    bool Delete(int ClaseId);
}
