using CharacterBuilderShared.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterTests
{
    public class UnitTests
    {

        [SetUp]
        public void Setup()
        { }

        [Test]
        public void createplayerTest()
        {
            var player = new Player
            {
                PlayerName = "Charley",
                Username = "Roddy477",
                Pin = 7654
            };

            Assert.That(player.PlayerName, Is.EqualTo("Charley"));
            Assert.That(player.Username, Is.EqualTo("Roddy477"));
            Assert.That(player.Pin, Is.EqualTo(7654));
        }

        [Test]
        public void createCharacterTest()
        {
            var player = new Player
            {
                Id = 0,
                PlayerName = "Charley",
                Username = "Roddy477",
                Pin = 7654
            };

            Assert.That(player.PlayerName, Is.EqualTo("Charley"));
            Assert.That(player.Username, Is.EqualTo("Roddy477"));
            Assert.That(player.Pin, Is.EqualTo(7654));

            var character = new Character
            {
                PlayerId = 0,
                CharName = "Hope",
                RaceId = 7
            };

            Assert.That(character.CharName, Is.EqualTo("Hope"));
            Assert.That(character.PlayerId, Is.EqualTo(0));
            Assert.That(character.RaceId, Is.EqualTo(7));
        }

        [Test]
        public void createStatsTest()
        {
            var player = new Player
            {
                Id = 0,
                PlayerName = "Charley",
                Username = "Roddy477",
                Pin = 7654
            };

            Assert.That(player.PlayerName, Is.EqualTo("Charley"));
            Assert.That(player.Username, Is.EqualTo("Roddy477"));
            Assert.That(player.Pin, Is.EqualTo(7654));


            var stats = new Stats
            {
                Id = 0,
                BaseCha = 17,
                BaseCon = 15
            };
            var character = new Character
            {
                PlayerId = 0,
                CharName = "Hope",
                RaceId = 7,
                StatsId = 0
            };

            Assert.That(character.CharName, Is.EqualTo("Hope"));
            Assert.That(character.PlayerId, Is.EqualTo(0));
            Assert.That(character.RaceId, Is.EqualTo(7));

            Assert.That(character.StatsId, Is.EqualTo(0));
            Assert.That(stats.Id, Is.EqualTo(0));
            Assert.That(stats.BaseCha, Is.EqualTo(17));
            Assert.That(stats.BaseCon, Is.EqualTo(15));
            Assert.That(stats.BaseDex, Is.EqualTo(0));
        }

    }
}
