using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly ILogger<StatsController> _logger;
        private StatsService _StatsService;

        public StatsController(ILogger<StatsController> logger, StatsService statsService)
        {
            _logger = logger;
            _StatsService = statsService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Stats>> GetAllStats()
        {
            return await _StatsService.GetAllStats();
        }

        [HttpGet("{id}")]
        public async Task<Stats> GetStatsById(int id)
        {
            return await _StatsService.GetStatsById(id);
        }

        [HttpPost()]
        public async Task AddStats(Stats stats)
        {
            await _StatsService.AddStats(stats);
        }

        [HttpDelete("{id}")]
        public async Task DeleteStats(int id)
        {
            await _StatsService.DeleteStats(id);
        }

        [HttpPut()]
        public async Task UpdateStats(Stats stats)
        {
            await _StatsService.UpdateStats(stats);
        }




    }
}
