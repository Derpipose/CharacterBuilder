using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public class RaceVarApiService
    {
        private readonly HttpClient _httpClient;
        public RaceVarApiService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<RaceVar>?> GetAllVarRace()
        {
            return await _httpClient.GetFromJsonAsync<List<RaceVar>>("RaceVar");

        }

        public async Task<RaceVar?> GetThisVarRaceString(string race)
        {
            return await _httpClient.GetFromJsonAsync<RaceVar>($"RaceVar/race/{race}");
        }

        public async Task<RaceVar?> GetThisVarRaceById(int id)
        {
            return await _httpClient.GetFromJsonAsync<RaceVar>($"RaceVar/{id}");
        }

        public async Task UpdateThisVarRace(RaceVar raceVar)
        {
            await _httpClient.PutAsJsonAsync("RaceVar", raceVar);
        }




    }
}
