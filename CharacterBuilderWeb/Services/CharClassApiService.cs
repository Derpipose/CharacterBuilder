using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public class CharClassApiService
    {
        private readonly HttpClient client;
        public CharClassApiService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<List<CharClass>?> GetAllCharClasses()
        {
            return await client.GetFromJsonAsync<List<CharClass>>("CharClass");
        }

        public async Task<List<CharClass>?> GetAllClassesByType(string type)
        {
            return await client.GetFromJsonAsync<List<CharClass>>($"CharClass/type/{type}");
        }

        public async Task<CharClass?> GetThisCharClass(int id)
        {
            return await client.GetFromJsonAsync<CharClass>($"CharClass/{id}");
        }

        public async Task UpdateThisCharClass(CharClass newcharclass)
        {
            await client.PutAsJsonAsync("CharClass", newcharclass);
        }
    }
}
