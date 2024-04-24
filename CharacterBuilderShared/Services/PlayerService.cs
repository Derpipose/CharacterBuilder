using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class PlayerService
    {
        private readonly ILogger<Player> _logger;
        private BuilderContext _DbContext;
        public PlayerService(ILogger<Player> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var mylist = await _DbContext.Player.ToListAsync();
            List<Player> list = new List<Player>();
            list = mylist;
            // CharacterMonitoring.playerupDownCounter = list.Count;
            return list;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _DbContext.Player.Where(T => T.Id == id).FirstOrDefaultAsync();
            if (player == null) { player = new Player(); }
            return player;
        }

        public async Task AddPlayer(Player player)
        {

            if (player != null)
            {
                _DbContext.Player.Add(player);
                await _DbContext.SaveChangesAsync();
                CharacterMonitoring.playerupDownCounter.Add(1);
            }
            // else{
            //     throw new Exception ("Player not defined properly");
            // }
        }


        public async Task DeletePlayer(int id)
        {
            var player = await _DbContext.Player.Where(T => T.Id == id).FirstOrDefaultAsync();
            if (player != null)
            {
                _DbContext.Player.Remove(player);
                CharacterMonitoring.playerupDownCounter.Add(-1);
                CharacterMonitoring.playerdeletecounter += 1;

            }
            // else {
            //     throw new Exception ("Player not found or deleted properly");
            // }
            await _DbContext.SaveChangesAsync();
        }


        public async Task UpdatePlayer(Player player)
        {
            var oldplayer = await _DbContext.Player.Where(T => T.Id == player.Id).FirstOrDefaultAsync();
            if (oldplayer != null)
            {
                oldplayer.PlayerName = player.PlayerName;
                oldplayer.Veteran = player.Veteran;
                oldplayer.Pin = player.Pin;
            }

            await _DbContext.SaveChangesAsync();
            CharacterMonitoring.playerupdatecounter += 1;
        }

    }
}
