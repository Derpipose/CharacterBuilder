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
            await _StatsService.GetAllStats();
        }

        [HttpGet("{id}")]
        public async Task<Stats> GetById(int id)
        {
            await _StatsService.GetStatsById(id);
        }

        [HttpPost()]
        public async Task Add(Stats stats)
        {
            await _StatsService.AddStats(stats);
        }

        [HttpDelete("/delete/{id}")]
        public async Task Delete(int id)
        {
            await _StatsService.DeleteStats(id);
        }

        [HttpPut("/update")]
        public async Task Update(Stats stats)
        {
            await _StatsService.UpdateStats(stats);
        }




    }
}
