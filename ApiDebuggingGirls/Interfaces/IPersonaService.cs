public interface IPersonaService
{
    IEnumerable<Persona> GetAll();
    Persona? GetById(int PersonaId);
    Persona Create(PersonaDTO personaDto);
    bool Delete(int PersonaId);
    Persona? Update(int PersonaId, PersonaDTO updatedPersonaDto);

    // Método para guardar cambios en el servicio.
    void Save();
}
