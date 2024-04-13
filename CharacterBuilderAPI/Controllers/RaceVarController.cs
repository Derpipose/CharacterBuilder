using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceVarController : ControllerBase
    {
        private readonly ILogger<RaceVarController> _logger;
        private RaceVar _RaceVar;

        public RaceVarController(ILogger<RaceVarController> logger, RaceVar raceVar)
        {
            _logger = logger;
            _RaceVar = raceVar;
        }

        [HttpGet()]
        public async Task<IEnumerable<>> GetAllRaceVar()
        {
            await _RaceVar.GetAllRaceVar();
        }

        [HttpGet("/race/{race}")]
        public async Task<> GetAllRaceVarByRace(string race)
        {
            await _RaceVar.GetAllRaceVarByRace(race);
        }
        [HttpGet("{id}")]
        public async Task<> GetRaceVarById(int id)
        {
        }

        [HttpPut("/update")]
        public async Task Update(RaceVar raceVar)
        {
            await _RaceVar.UpdateRaceVar(raceVar);
        }




    }
}
