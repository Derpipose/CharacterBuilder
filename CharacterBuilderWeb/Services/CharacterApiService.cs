using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public class CharacterApiService
    {

        private readonly HttpClient client;
        public CharacterApiService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<List<Character>?> GetAllCharacters()
        {
            return await client.GetFromJsonAsync<List<Character>>("Character");
        }

        public async Task<List<Character>?> GetAllCharacterByPlayerId(int id)
        {
            return await client.GetFromJsonAsync<List<Character>>($"Character/character/player/{id}");
        }

        public async Task<Character?> GetThisCharacter(int id)
        {
            return await client.GetFromJsonAsync<Character>($"Character/{id}");
        }

        public async Task AddThisCharacter(Character newcharacter)
        {
            await client.PostAsJsonAsync("Character", newcharacter);
        }

        public async Task UpdateThisCharacter(Character newcharacter)
        {
            await client.PutAsJsonAsync("Character", newcharacter);
        }

        public async Task DeleteThisCharacter(int id)
        {
            await client.DeleteAsync($"Character/{id}");
        }
    }
}
