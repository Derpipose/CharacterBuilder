using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterBuilderShared.Models;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderWeb.Services
{
    public partial class CharacterBusiness
    {
        private readonly ILogger<CharacterBusiness> logger;
        private ICharacterApiService characterApiService;
        private IStatsApiService statsApiService;
        public CharacterBusiness(ICharacterApiService service, ILogger<CharacterBusiness> _logger, IStatsApiService stats)
        {
            logger = _logger;
            statsApiService = stats;
            characterApiService = service;
        }


        public async Task GiveStats(Character workingcharacter, Stats workingstats, Player workingplayer)
        {
            List<Character> ?oldcharlist = await characterApiService.GetAllCharacterByPlayerId(workingplayer.Id) ?? null;
            if (oldcharlist == null)
            {
                oldcharlist = new List<Character>();
            }
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

            oddCharacter = charlist.FirstOrDefault(c => !oldcharlist.Select(oldc => oldc.Id).Contains(c.Id));
            /*foreach (Character newChar in charlist)
            {
                *//*foreach(Character oldChar in oldcharlist)
                {
                    if(oldChar.Id != newChar.Id)
                    {

                    }
                }*//*
                oddCharacter = oldcharlist?.FirstOrDefault(c => c.Id != newChar.Id);

                if (oldcharlist?.FirstOrDefault(c => c.Id == newChar.Id) != null)
                {
                    oddCharacter = newChar;
                    break;
                }
            }*/

            if (oddCharacter == null)
            {
                oddCharacter = new Character();
            }
            workingstats.Id = oddCharacter.Id;
            await statsApiService.AddThisStats(workingstats);
            oddCharacter.StatsId = workingstats.Id;
            await characterApiService.UpdateThisCharacter(oddCharacter);
        }
    }
}
