using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private CharacterService _CharacterService;

        public CharacterController(ILogger<CharacterController> logger, CharacterService characterService)
        {
            _logger = logger;
            _CharacterService = characterService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _CharacterService.GetAllCharacters();
        }

        [HttpGet("/character/player/{id}")]
        public async Task<IEnumerable<Character>> GetAllCharactersByPlayerId(int id)
        {
            return await _CharacterService.GetAllCharactersByPlayer(id);
        }


        [HttpGet("{id}")]
        public async Task<Character> GetCharacterById(int id)
        {
            return await _CharacterService.GetCharacterById(id);
        }

        [HttpPost()]
        public async Task AddCharacter(Character character)
        {
            await _CharacterService.AddCharacter(character);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCharacter(int id)
        {
            await _CharacterService.DeleteCharacter(id);
        }

        [HttpPut()]
        public async Task UpdateCharacter(Character character)
        {
            await _CharacterService.UpdateCharacter(character);
        }




    }
}
