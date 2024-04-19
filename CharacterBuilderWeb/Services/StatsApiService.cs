using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public class StatsApiService
    {
        private readonly HttpClient client;
        public StatsApiService(HttpClient httpclient)
        {
            client = httpclient;
        }

        public async Task<Stats?> GetThisStats(int number)
        {
            return await client.GetFromJsonAsync<Stats>($"Stats/{number}");
        }

        public async Task AddThisStats(Stats newstats)
        {
            await client.PostAsJsonAsync("Stats", newstats);
        }

        public async Task DeleteThisStats(int number)
        {
            await client.DeleteAsync($"Stats/{number}");
        }

        public async Task UpdateThisStats(Stats newstats)
        {
            await client.PutAsJsonAsync("Stats", newstats);
        }

    }
}
