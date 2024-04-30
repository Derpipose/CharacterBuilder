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

        [LoggerMessage(Level = LogLevel.Information, Message = "Hello World! Logging is {Description}.")]
        static partial void LogStartupMessage(ILogger logger, string description);



        [LoggerMessage(Level = LogLevel.Information, Message = "1 Player is being {Description}.")]
        static partial void LogFunctionMessage(ILogger logger, string description);



        [LoggerMessage(Level = LogLevel.Warning, Message = "CAUSE FOR CONCERN! {Description}.")]
        static partial void LogWarningMessage(ILogger logger, string description);


        [LoggerMessage(Level = LogLevel.Error, Message = "An Error Has Occurred! {Description}")]
        static partial void LogErrorMessage(ILogger logger, string description);

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var mylist = await _DbContext.Player.ToListAsync();
            List<Player> list = new List<Player>();
            list = mylist;
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
                CharacterMonitoring.playercreatecounter += 1;
                LogFunctionMessage(_logger, "added");
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
                LogFunctionMessage(_logger, "deleted");

                var loggerFactory = new LoggerFactory();
                var statslogger = loggerFactory.CreateLogger<Stats>();
                var characterLogger = loggerFactory.CreateLogger<Character>();
                CharacterService charservice = new(characterLogger, _DbContext);

                var characters = await charservice.GetAllCharactersByPlayer(id);
                List<Character> characterlist = characters.ToList();
                if (characterlist.Count > 0)
                {
                    foreach (var character in characterlist)
                    {
                        await charservice.DeleteCharacter(character.Id);
                    }
                }
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
                LogFunctionMessage(_logger, "updated");

            }

            await _DbContext.SaveChangesAsync();
            CharacterMonitoring.playerupdatecounter += 1;
        }

    }
}
