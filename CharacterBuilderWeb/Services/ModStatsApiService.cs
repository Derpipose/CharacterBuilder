using CharacterBuilderShared.Models;


namespace CharacterBuilderWeb.Services
{
    public class ModStatsApiService
    {
        private readonly HttpClient client;
        public ModStatsApiService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<ModStats?> GetThisModStats(int number)
        {
            return await client.GetFromJsonAsync<ModStats>($"ModStats/{number}");
        }

        public async Task AddThisModStats(ModStats newstats)
        {
            await client.PostAsJsonAsync("ModStats", newstats);
        }

        public async Task DeleteThisModStats(int number)
        {
            await client.DeleteAsync($"ModStats/{number}");
        }

        public async Task UpdateThisModStats(ModStats newstats)
        {
            await client.PutAsJsonAsync("ModStats", newstats);
        }
    }


}
