using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public class CharRaceApiService
    {
        private readonly HttpClient client;

        public CharRaceApiService(HttpClient httpclient)
        {
            client = httpclient;
        }
        public async Task<List<CharRace>?> GetAllRaces()
        {
            return await client.GetFromJsonAsync<List<CharRace>>("CharRace");
        }

        public async Task<List<CharRace>?> GetAllRacesPerCampaign(string campaign)
        {
            return await client.GetFromJsonAsync<List<CharRace>>($"CharRace/campaign/{campaign}");
        }

        public async Task<CharRace?> GetThisRace(int id)
        {
            return await client.GetFromJsonAsync<CharRace>($"CharRace/{id}");
        }


        public async Task UpdateThisRace(CharRace newRace)
        {
            await client.PutAsJsonAsync("CharRace", newRace);
        }

    }
}
