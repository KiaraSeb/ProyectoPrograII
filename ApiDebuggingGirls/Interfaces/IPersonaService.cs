public interface IPersonaService
{
    IEnumerable<Persona> GetAll();
    Persona? GetById(int PersonaId);
    Persona Create(PersonaDTO personaDto);
    bool Delete(int PersonaId); // Cambiado de void a bool
    Persona? Update(int PersonaId, PersonaDTO updatedPersonaDto);
}
