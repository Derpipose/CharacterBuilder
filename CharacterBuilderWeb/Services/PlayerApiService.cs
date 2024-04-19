using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public class PlayerApiService
    {

        private readonly HttpClient client;
        public PlayerApiService(HttpClient httpclient)
        {
            client = httpclient;
        }

        public async Task<List<Player>?> GetAllPlayers()
        {
            return await client.GetFromJsonAsync<List<Player>>("Player");
        }

        public async Task<Player?> GetThisPlayer(int id)
        {
            return await client.GetFromJsonAsync<Player>($"Player/{id}");
        }

        public async Task AddThisPlayer(Player newplayer)
        {
            await client.PostAsJsonAsync("Player", newplayer);
        }

        public async Task UpdateThisPlayer(Player newplayer)
        {
            await client.PutAsJsonAsync("Player", newplayer);
        }

        public async Task DeleteThisPlayer(int id)
        {
            await client.DeleteAsync($"Player/{id}");
        }
    }
}
