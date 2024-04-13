using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private CharacterService _CharacterService

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

        [HttpGet("/player/{id}")]
        public async Task<Character> GetAllCharactersByPlayerId(int id)
        {
            return await _CharacterService.GetAllCharactersByPlayer(id);
        }


        [HttpGet("{id}")]
        public async Task<Character> GetCharacterById(int id)
        {
            return await _CharacterService.GetCharacterById();
        }

        [HttpPost()]
        public async Task Add(Character character)
        {
            await _CharacterService.AddCharacter(character);
        }

        [HttpDelete("/delete/{id}")]
        public async Task Delete(int id)
        {
            await _CharacterService.DeleteCharacter(id);
        }

        [HttpPut("/update")]
        public async Task Update(Character character)
        {
            await _CharacterService.UpdateCharacter(character);
        }




    }
}
