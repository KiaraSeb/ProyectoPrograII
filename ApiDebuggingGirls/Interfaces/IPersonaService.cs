public interface IPersonaService
{
    IEnumerable<Persona> GetAll();
    Persona? GetById(int id);
    Persona Create(PersonaDTO personaDto);
    void Delete(int id);
    Persona? Update(int id, Persona persona);
}
