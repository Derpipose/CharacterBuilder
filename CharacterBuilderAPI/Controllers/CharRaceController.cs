using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharRaceController : ControllerBase
    {
        private readonly ILogger<CharRaceController> _logger;
        private CharRaceService _CharRaceService;

        public CharRaceController(ILogger<CharRaceController> logger, CharRaceService charRaceService)
        {
            _logger = logger;
            _CharRaceService = charRaceService;
        }

        [HttpGet()]
        public async Task<IEnumerable<CharRace>> GetAllRaces()
        {
            return await _CharRaceService.GetAllRaces();
        }

        [HttpGet("/campaign/{campaign}")]
        public async Task<IEnumerable<CharRace>> GetRacesByCampaign(string campaign)
        {
            return await _CharRaceService.GetAllRacesByCampaign(campaign);
        }


        [HttpGet("{id}")]
        public async Task<CharRace> GetRaceById(int id)
        {
            return await _CharRaceService.GetRaceById(id);
        }



        [HttpPut("")]
        public async Task UpdateRace(CharRace charRace)
        {
            await _CharRaceService.UpdateRace(charRace);
        }




    }
}
