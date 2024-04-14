using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModStatsController : ControllerBase
    {
        private readonly ILogger<ModStatsController> _logger;
        private ModStatsService _ModStatsService;

        public ModStatsController(ILogger<ModStatsController> logger, ModStatsService modStatsService)
        {
            _logger = logger;
            _ModStatsService = modStatsService;
        }



        [HttpGet("{id}")]
        public async Task<ModStats> GetModStatsById(int id)
        {
            return await _ModStatsService.GetModStats(id);
        }

        [HttpPost()]
        public async Task AddModStats(ModStats modStats)
        {
            await _ModStatsService.AddModStats(modStats);
        }

        [HttpDelete("{id}")]
        public async Task DeleteModStats(int id)
        {
            await _ModStatsService.DeleteModStats(id);
        }

        [HttpPut()]
        public async Task UpdateModStats(ModStats modStats)
        {
            await _ModStatsService.UpdateModStats(modStats);
        }




    }
}
