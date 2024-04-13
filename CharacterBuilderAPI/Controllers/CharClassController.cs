using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharClassController : ControllerBase
    {
        private readonly ILogger<CharClassController> _logger;
        private CharClass _CharClass;

        public CharClassController(ILogger<CharClassController> logger, CharClass charClass)
        {
            _logger = logger;
            _CharClass = charClass;
        }

        [HttpGet()]
        public async Task<IEnumerable<>> GetAll()
        {
            await _CharClass.GetAllCharClasses();
        }

        [HttpGet("/type/{type}")]
        public async Task<> GetById(string type)
        {
            await _CharClass.GetAllCharClassByType(type);
        }

        [HttpGet("{id}")]
        public async Task<> GetById(int id)
        {
            await _CharClass.GetCharClassById(id);
        }

        [HttpPut("/update")]
        public async Task Update(CharClass charClass)
        {
            await _CharClass.UpdateClass(charClass);
        }




    }
}
