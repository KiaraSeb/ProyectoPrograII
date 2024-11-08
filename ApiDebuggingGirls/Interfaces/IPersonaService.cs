public interface IPersonaService
{
    IEnumerable<Persona> GetAll();
    Persona? GetById(int PersonaId);
    Persona Create(PersonaDTO personaDto);
    bool Delete(int PersonaId);
    Persona? Update(int PersonaId, PersonaDTO updatedPersonaDto);

    // Nueva firma del método para actualizar especialidades de una persona
    Persona? UpdateEspecialidades(int personaId, List<int> especialidadIds);
}
