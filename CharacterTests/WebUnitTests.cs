using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterBuilderShared.Models;
using CharacterBuilderWeb.Components.Pages;
using CharacterBuilderWeb.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;


namespace CharacterTests
{
    internal class WebUnitTests
    {



        [Order(1)]
        [Test]
        public async Task MakingAndFindingNewChar()
        {


            //GIVEN
            var Statsservice = Substitute.For<IStatsApiService>();
            var characterService = Substitute.For<ICharacterApiService>();
            var loggingfactory = new LoggerFactory();
            var logger = loggingfactory.CreateLogger<CharacterBusiness>();

            CharacterBusiness business = new CharacterBusiness(characterService, logger, Statsservice);
            List<Character>? firstcharacters = [new Character { Id = 1, CharName = "dylan", PlayerId = 1 }];
            List<Character>? secondcharacters = [new Character { Id = 1, CharName = "dylan", PlayerId = 1 }, new Character { Id = 2, CharName = "Bob", PlayerId = 1 }];
            characterService.GetAllCharacterByPlayerId(1).Returns(firstcharacters, secondcharacters);
            Character newchar = new Character { CharName = "Bob", PlayerId = 1 };
            Stats newstats = new Stats();
            Player player = new Player { Id = 1, PlayerName = "ble", Username = "kse", Pin = 4565 };
            await business.GiveStats(newchar, newstats, player);



            //WHEN
            //Getlist for compare
            //add character
            //get newlist for compare
            //Get odd character

            await characterService.Received().AddThisCharacter(Arg.Is<Character>(c => c.PlayerId == 1));
            await Statsservice.Received().AddThisStats(Arg.Is<Stats>(s => s.Id == 2));
            await characterService.Received().UpdateThisCharacter(Arg.Is<Character>(c => c.StatsId == 2));
            //THEN
            //When the character has Id
            //When the character has StatsId

        }
    }
}
