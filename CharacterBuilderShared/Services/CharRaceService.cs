using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class CharRaceService
    {
        private readonly ILogger<CharRace> _logger;
        private BuilderContext _DbContext;
        public CharRaceService(ILogger<CharRace> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;

        }

        public async Task<IEnumerable<CharRace>> GetAllRaces()
        {
            var mylist = await _DbContext.CharacterRace.ToListAsync();
            List<CharRace> list = new List<CharRace>();
            list = mylist;
            return list;
        }

        public async Task<IEnumerable<CharRace>> GetAllRacesByCampaign(string campaign)
        {
            var mylist = await _DbContext.CharacterRace.Where(x => x.Campaign == campaign).ToListAsync();
            List<CharRace> list = new List<CharRace>();
            list = mylist;
            return list;
        }

        public async Task<CharRace> GetRaceById(int id)
        {
            var race = await _DbContext.CharacterRace.Where(x => x.Id == id).FirstOrDefaultAsync();
            return race == null ? throw new Exception("Race not found!") : race;
        }

        public async Task UpdateRace(CharRace race)
        {
            var oldrace = await _DbContext.CharacterRace.Where(x => x.Id == race.Id).FirstOrDefaultAsync();
            if (oldrace != null)
            {
                oldrace.Campaign = race.Campaign;
                oldrace.SubType = race.SubType;
                oldrace.RaceDescription = race.RaceDescription;
                oldrace.Special = race.Special;
                oldrace.Str = race.Str;
                oldrace.Dex = race.Dex;
                oldrace.Con = race.Con;
                oldrace.Wis = race.Wis;
                oldrace.RaceInt = race.RaceInt;
                oldrace.Cha = race.Cha;
                oldrace.Pick = race.Pick;
                oldrace.BonusMana = race.BonusMana;
                oldrace.AddOrMultMana = race.AddOrMultMana;
            }
            await _DbContext.SaveChangesAsync();
        }


    }
}
