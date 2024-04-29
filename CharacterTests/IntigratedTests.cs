using CharacterBuilderShared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterTests
{
    public class Tests
    {

        PlayerService playerService;
        CharacterService characterService;
        CharClassService charClassService;
        StatsService statsService;
        CharRaceService charRaceService;
        RaceVarService raceVarService;

        [SetUp]
        public void Setup()
        {

            string connection = "host=test-my_postgres_db:5432;Database=mydatabase;Username=myusername;Password=mypassword;";
            DbContextOptions<BuilderContext> options = new DbContextOptionsBuilder<BuilderContext>()
            .UseNpgsql(connection)
            .Options;
            var loggerFactory = new LoggerFactory();

            var playerlogger = loggerFactory.CreateLogger<Player>();
            var characterlogger = loggerFactory.CreateLogger<Character>();
            var classlogger = loggerFactory.CreateLogger<CharClass>();
            var statslogger = loggerFactory.CreateLogger<Stats>();
            var racelogger = loggerFactory.CreateLogger<CharRace>();
            var racevarlogger = loggerFactory.CreateLogger<RaceVar>();

            BuilderContext dbContext = new BuilderContext(options);
            playerService = new(playerlogger, dbContext);
            characterService = new(characterlogger, dbContext);
            charClassService = new(classlogger, dbContext);
            statsService = new(statslogger, dbContext);
            charRaceService = new(racelogger, dbContext);
            raceVarService = new(racevarlogger, dbContext);


        }

        [Order(1)]
        [Test]
        public void PlayerCreate()
        {
            Player player = new Player
            {
                Pin = 1234,
                PlayerName = "Hilton",
                Username = "Hamilioton"
            };
            Assert.That(player, Is.Not.Null);
            Assert.That(player.PlayerName, Is.EqualTo("Hilton"));
            Assert.That(player.Username, Is.EqualTo("Hamilioton"));
            Assert.That(player.Pin, Is.EqualTo(1234));
        }

        [Order(2)]
        [Test]
        public async Task PlayerAdd()
        {
            Player player = new Player
            {
                Pin = 1234,
                PlayerName = "Hilton",
                Username = "Hamilioton"
            };
            Assert.That(player, Is.Not.Null);
            Assert.That(player.PlayerName, Is.EqualTo("Hilton"));
            Assert.That(player.Username, Is.EqualTo("Hamilioton"));
            Assert.That(player.Pin, Is.EqualTo(1234));
            await playerService.AddPlayer(player);
            var mylist = await playerService.GetAllPlayers();
            List<Player> list = mylist.ToList();
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].PlayerName, Is.EqualTo("Hilton"));
            Assert.That(list[0].Username, Is.EqualTo("Hamilioton"));
            Assert.That(list[0].Pin, Is.EqualTo(1234));

        }


        [Order(3)]
        [Test]
        public async Task PlayerModify()
        {

            var mylist = await playerService.GetAllPlayers();
            List<Player> list = mylist.ToList();
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].PlayerName, Is.EqualTo("Hilton"));
            Assert.That(list[0].Username, Is.EqualTo("Hamilioton"));
            Assert.That(list[0].Pin, Is.EqualTo(1234));
            Player updateplayer = new Player
            {
                Id = 1,
                Username = "Test",
                PlayerName = "Hamilton",
                Pin = 4321
            };
            await playerService.UpdatePlayer(updateplayer);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].PlayerName, Is.EqualTo("Hamilton"));
            Assert.That(list[0].Username, Is.EqualTo("Hamilioton"));
            Assert.That(list[0].Pin, Is.EqualTo(4321));
        }


        [Order(4)]
        [Test]
        public async Task playerdelete()
        {
            var mylist = await playerService.GetAllPlayers();
            List<Player> list = mylist.ToList();
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].PlayerName, Is.EqualTo("Hamilton"));
            Assert.That(list[0].Username, Is.EqualTo("Hamilioton"));
            Assert.That(list[0].Pin, Is.EqualTo(4321));
            await playerService.DeletePlayer(1);
            mylist = await playerService.GetAllPlayers();
            list = mylist.ToList();
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Order(5)]
        [Test]
        public async Task GetOnePlayer()
        {
            Player player = new Player
            {
                Pin = 1234,
                PlayerName = "Hilton",
                Username = "Hamilioton"
            };
            Assert.That(player, Is.Not.Null);
            Assert.That(player.PlayerName, Is.EqualTo("Hilton"));
            Assert.That(player.Username, Is.EqualTo("Hamilioton"));
            Assert.That(player.Pin, Is.EqualTo(1234));
            await playerService.AddPlayer(player);
            var mylist = await playerService.GetAllPlayers();

            List<Player> list = mylist.ToList();
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].PlayerName, Is.EqualTo("Hilton"));
            Assert.That(list[0].Username, Is.EqualTo("Hamilioton"));
            Assert.That(list[0].Pin, Is.EqualTo(1234));

            Player secondplayer = new Player
            {
                Pin = 7665,
                PlayerName = "Church",
                Username = "GrimmSlayer55"
            };
            Assert.That(secondplayer, Is.Not.Null);
            Assert.That(secondplayer.PlayerName, Is.EqualTo("Church"));
            Assert.That(secondplayer.Username, Is.EqualTo("GrimmSlayer55"));
            Assert.That(secondplayer.Pin, Is.EqualTo(7665));
            await playerService.AddPlayer(secondplayer);


            mylist = await playerService.GetAllPlayers();
            list = mylist.ToList();
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list[1].PlayerName, Is.EqualTo("Church"));
            Assert.That(list[1].Username, Is.EqualTo("GrimmSlayer55"));
            Assert.That(list[1].Pin, Is.EqualTo(7665));

            var check = await playerService.GetPlayerById(2);
            Player checkplayer = check;

            Assert.That(checkplayer.PlayerName, Is.EqualTo("Hilton"));
            Assert.That(checkplayer.Username, Is.EqualTo("Hamilioton"));
            Assert.That(checkplayer.Pin, Is.EqualTo(1234));

        }


        //Characters


        [Order(6)]
        [Test]
        public async Task addandassignCharacter()
        {
            Character character = new Character
            {
                PlayerId = 2,
                CharName = "A",
            };
            Assert.That(character.PlayerId, Is.EqualTo(2));
            Assert.That(character.CharName, Is.EqualTo("A"));
            Assert.That(character.RaceId, Is.Null);
            await characterService.AddCharacter(character);
            var characters = await characterService.GetAllCharactersByPlayer(2);
            List<Character> list = characters.ToList();
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Order(7)]
        [Test]
        public async Task GetCharacterbyid()
        {
            Character character = new Character
            {
                PlayerId = 2,
                CharName = "B",
            };
            Assert.That(character.PlayerId, Is.EqualTo(2));
            Assert.That(character.CharName, Is.EqualTo("B"));
            Assert.That(character.RaceId, Is.Null);
            await characterService.AddCharacter(character);
            var characters = await characterService.GetAllCharactersByPlayer(2);
            List<Character> list = characters.ToList();
            Assert.That(list.Count, Is.EqualTo(2));

            var checkCharacter = await characterService.GetCharacterById(2);
            Character character1 = checkCharacter;

            Assert.That(character1.PlayerId, Is.EqualTo(2));
            Assert.That(character1.CharName, Is.EqualTo("B"));
        }

        /*[Order(8)]
        [Test]
        public async Task MakingAndFindingNewChar()
        {
            //GIVEN



            //WHEN
            //Getlist for compare
            //add character
            //get newlist for compare
            //Get odd character

            //THEN
            //When the character has Id
            //When the character has StatsId

        }*/



    }



}
