using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterBuilderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private PlayerService _PlayerService;

        public PlayerController(ILogger<PlayerController> logger, PlayerService playerService)
        {
            _logger = logger;
            _PlayerService = playerService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _PlayerService.GetAllPlayers();
        }

        [HttpGet("{id}")]
        public async Task<Player> GetPlayerById(int id)
        {
            return await _PlayerService.GetPlayerById(id);
        }

        [HttpPost()]
        public async Task AddPlayer(Player player)
        {
            await _PlayerService.AddPlayer(player);
        }

        [HttpDelete("/delete/{id}")]
        public async Task DeletePlayer(int id)
        {
            await _PlayerService.DeletePlayer(id);
        }

        [HttpPut("/update")]
        public async Task UpdatePlayer(Player player)
        {
            await _PlayerService.UpdatePlayer(player);
        }




    }
}
