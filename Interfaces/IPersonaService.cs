public interface IPersonaService
{
    Task<IEnumerable<PersonaDto>> GetAllPersonasAsync();
    Task<PersonaDto> CreatePersonaAsync(PersonaDto personaDto);
}
