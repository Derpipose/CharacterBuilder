using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharRaceController : ControllerBase
    {
        private readonly ILogger<CharRaceController> _logger;
        private CharRace _CharRace;

        public CharRaceController(ILogger<CharRaceController> logger, CharRace charRace)
        {
            _logger = logger;
            _CharRace = charRace;
        }

        [HttpGet()]
        public async Task<IEnumerable<>> GetAllRaces()
        {
            await _CharRace.GetAllRaces();
        }

        [HttpGet("/campaign/{campaign}")]
        public async Task<> GetRacesByCampaign(string campaign)
        {
            await _CharRace.GetAllRacesByCampaign(campaign);
        }


        [HttpGet("{id}")]
        public async Task<> GetRaceById(int id)
        {
            await _CharRace.GetRaceById(id);
        }



        [HttpPut("/update")]
        public async Task Update(CharRace charRace)
        {
            await _CharRace.UpdateRace(charRace);
        }




    }
}
