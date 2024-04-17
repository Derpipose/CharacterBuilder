using CharacterBuilderShared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterTests
{
    public class Tests
    {

        PlayerService playerService;
        [SetUp]
        public void Setup()
        {

            string connection = "host=test-my_postgres_db:5432;Database=mydatabase;Username=myusername;Password=mypassword;";
            DbContextOptions<BuilderContext> options = new DbContextOptionsBuilder<BuilderContext>()
            .UseNpgsql(connection)
            .Options;
            var loggerFactory = new LoggerFactory();

            var characterlogger = loggerFactory.CreateLogger<Player>();

            BuilderContext characterdbContext = new BuilderContext(options);
            playerService = new(characterlogger, characterdbContext);

        }

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






    }
}
