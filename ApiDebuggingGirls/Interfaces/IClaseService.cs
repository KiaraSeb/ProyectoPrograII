using System.Collections.Generic;

public interface IClaseService
{
    List<Clase> GetAll();
    Clase GetById(int ClaseId);
}
