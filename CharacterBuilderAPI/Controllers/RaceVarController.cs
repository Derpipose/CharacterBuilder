using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceVarController : ControllerBase
    {
        private readonly ILogger<RaceVarController> _logger;
        private RaceVarService _RaceVarService;

        public RaceVarController(ILogger<RaceVarController> logger, RaceVarService raceVarService)
        {
            _logger = logger;
            _RaceVarService = raceVarService;
        }

        [HttpGet()]
        public async Task<IEnumerable<RaceVar>> GetAllRaceVar()
        {
            return await _RaceVarService.GetAllRaceVar();
        }

        [HttpGet("/race/{race}")]
        public async Task<IEnumerable<RaceVar>> GetAllRaceVarByRace(string race)
        {
            return await _RaceVarService.GetAllRaceVarByRace(race);
        }
        [HttpGet("{id}")]
        public async Task<RaceVar> GetRaceVarById(int id)
        {
            return await _RaceVarService.GetRaceVarById(id);
        }

        [HttpPut()]
        public async Task Update(RaceVar raceVar)
        {
            await _RaceVarService.UpdateRaceVar(raceVar);
        }




    }
}
