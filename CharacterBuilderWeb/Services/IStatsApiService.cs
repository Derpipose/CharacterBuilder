using CharacterBuilderShared.Models;

namespace CharacterBuilderWeb.Services
{
    public interface IStatsApiService
    {
        Task<List<Stats>?> GetAllStats();
        Task AddThisStats(Stats newstats);
        Task DeleteThisStats(int number);
        Task<Stats?> GetThisStats(int number);
        Task UpdateThisStats(Stats newstats);
    }
}
