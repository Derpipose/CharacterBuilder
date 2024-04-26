using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class CharacterService
    {
        private readonly ILogger<Character> _logger;
        private BuilderContext _DbContext;
        public CharacterService(ILogger<Character> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;
            LogStartupMessage(logger, "Fun");
        }

        [LoggerMessage(Level = LogLevel.Information, Message = "Hello World! Logging is {Description}.")]
        static partial void LogStartupMessage(ILogger logger, string description);



        [LoggerMessage(Level = LogLevel.Information, Message = "1 Character is being {Description}.")]
        static partial void LogFunctionMessage(ILogger logger, string description);



        [LoggerMessage(Level = LogLevel.Warning, Message = "CAUSE FOR CONCERN! {Description}.")]
        static partial void LogWarningMessage(ILogger logger, string description);

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            var mylist = await _DbContext.PlayerCharacter.ToListAsync();
            List<Character> list = new List<Character>();
            list = mylist;
            // CharacterMonitoring.characterupDownCounter = list.Count;
            return list;
        }

        public async Task<IEnumerable<Character>> GetAllCharactersByPlayer(int id)
        {
            var mylist = await _DbContext.PlayerCharacter.Where(x => x.PlayerId == id).ToListAsync();
            List<Character> list = new List<Character>();
            list = mylist;
            return list;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _DbContext.PlayerCharacter.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (character == null) { character = new Character(); }
            Character character1 = character;
            return character1;
        }

        public async Task AddCharacter(Character character)
        {
            if (character != null)
            {
                _DbContext.PlayerCharacter.Add(character);
                await _DbContext.SaveChangesAsync();
                CharacterMonitoring.characterupDownCounter.Add(1);
                CharacterMonitoring.charactercreatecounter += 1;

            }
            // else{
            //     throw new Exception ("Character not defined properly");
            // }
        }

        public async Task DeleteCharacter(int id)
        {
            var character = await _DbContext.PlayerCharacter.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (character != null)
            {
                if (character.StatsId != null)
                {
                    var loggerFactory = new LoggerFactory();
                    var statslogger = loggerFactory.CreateLogger<Stats>();
                    StatsService service = new(statslogger, _DbContext);
                    int statid = (int)character.StatsId;
                    await service.DeleteStats(statid);
                }
                if (character.ModStatsId != null)
                {
                    var loggerFactory = new LoggerFactory();
                    var statslogger = loggerFactory.CreateLogger<ModStats>();
                    ModStatsService service = new(statslogger, _DbContext);
                    int statid = (int)character.ModStatsId;
                    await service.DeleteModStats(statid);
                }


                _DbContext.PlayerCharacter.Remove(character);
                await _DbContext.SaveChangesAsync();
                CharacterMonitoring.characterupDownCounter.Add(-1);
                CharacterMonitoring.characterdeletecounter += 1;

            }

        }

        public async Task UpdateCharacter(Character character)
        {
            var oldcharacter = await _DbContext.PlayerCharacter.Where(x => x.Id == character.Id).FirstOrDefaultAsync();
            if (oldcharacter != null)
            {
                oldcharacter.CharName = character.CharName;
                oldcharacter.RaceId = character.RaceId;
                oldcharacter.RaceVariantId = character.RaceVariantId;
                oldcharacter.StatsId = character.StatsId;
                oldcharacter.ModStatsId = character.ModStatsId;
            }

            await _DbContext.SaveChangesAsync();
            CharacterMonitoring.characterupdatecounter += 1;
        }

    }
}
