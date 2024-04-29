using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterBuilderShared.Models;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderWeb.Services
{
    internal partial class CharacterBusiness
    {
        private readonly ILogger<CharacterBusiness> logger;
        private CharacterApiService characterApiService;
        private StatsApiService statsApiService;
        public CharacterBusiness(CharacterApiService service, ILogger<CharacterBusiness> _logger, StatsApiService stats)
        {
            logger = _logger;
            statsApiService = stats;
            characterApiService = service;
        }


        public async Task GiveStats(Character workingcharacter, Stats workingstats, Player workingplayer)
        {
            List<Character>? oldcharlist = await characterApiService.GetAllCharacterByPlayerId(workingplayer.Id);
            workingcharacter.PlayerId = workingplayer.Id;
            await characterApiService.AddThisCharacter(workingcharacter);
            logger.LogInformation("I created a character and added it to the database!");

            List<Character>? charlist = await characterApiService.GetAllCharacterByPlayerId(workingplayer.Id);
            if (charlist == null)
            {
                charlist = new List<Character>();
            }
            // get odd character out and set stats.playerId = character.Id and character.StatsId = stats.Id
            Character? oddCharacter = new Character();
            foreach (Character newChar in charlist)
            {
                if (oldcharlist.FirstOrDefault(c => c.Id == newChar.Id) != null)
                {
                    oddCharacter = newChar;
                    break;
                }
            }
            workingstats.Id = oddCharacter.Id;
            await statsApiService.AddThisStats(workingstats);
            oddCharacter.StatsId = workingstats.Id;
            await characterApiService.UpdateThisCharacter(oddCharacter);
        }
    }
}
