using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharClassController : ControllerBase
    {
        private readonly ILogger<CharClassController> _logger;
        private CharClassService _CharClassService;

        public CharClassController(ILogger<CharClassController> logger, CharClassService charClass)
        {
            _logger = logger;
            _CharClassService = charClass;
        }

        [HttpGet()]
        public async Task<IEnumerable<CharClass>> GetAllCharClasses()
        {
            return await _CharClassService.GetAllCharClasses();

        }

        [HttpGet("/type/{type}")]
        public async Task<IEnumerable<CharClass>> GetCharClassByType(string type)
        {
            return await _CharClassService.GetAllCharClassByType(type);
        }

        [HttpGet("{id}")]
        public async Task<CharClass> GetCharClassById(int id)
        {
            return await _CharClassService.GetCharClassById(id);
        }

        [HttpPut()]
        public async Task UpdateCharClass(CharClass charClass)
        {
            await _CharClassService.UpdateClass(charClass);
        }




    }
}
