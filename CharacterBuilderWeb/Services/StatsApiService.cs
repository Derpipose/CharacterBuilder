using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public class StatsApiService : IStatsApiService
    {
        private readonly HttpClient client;
        public StatsApiService(HttpClient httpclient)
        {
            client = httpclient;
        }

        public async Task<List<Stats>?> GetAllStats()
        {
            return await client.GetFromJsonAsync<List<Stats>>("Stats");

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
