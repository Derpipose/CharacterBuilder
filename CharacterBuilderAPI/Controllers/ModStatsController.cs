using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModStatsController : ControllerBase
    {
        private readonly ILogger<ModStatsController> _logger;
        private ModStats _ModStats;

        public ModStatsController(ILogger<ModStatsController> logger, ModStats modStats)
        {
            _logger = logger;
            _ModStats = modStats;
        }



        [HttpGet("{id}")]
        public async Task<> GetById(int id)
        {
            await _ModStats.GetModStats(id);
        }

        [HttpPost()]
        public async Task Add(ModStats modStats)
        {
            await _ModStats.AddModStats(modStats);
        }

        [HttpDelete("/delete/{id}")]
        public async Task Delete(int id)
        {
            await _ModStats.DeleteModStats(id);
        }

        [HttpPut("/update")]
        public async Task Update(ModStats modStats)
        {
            await _ModStats.UpdateModStats(modStats);
        }




    }
}
