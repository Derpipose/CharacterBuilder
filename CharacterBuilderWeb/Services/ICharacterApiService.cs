using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public interface ICharacterApiService
    {
        Task AddThisCharacter(Character newcharacter);
        Task DeleteThisCharacter(int id);
        Task<List<Character>?> GetAllCharacterByPlayerId(int id);
        Task<List<Character>?> GetAllCharacters();
        Task<Character?> GetThisCharacter(int id);
        Task UpdateThisCharacter(Character newcharacter);
    }
}
