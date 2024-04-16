using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class RaceVarService
    {
        private readonly ILogger<RaceVar> _logger;
        private BuilderContext _DbContext;
        public RaceVarService(ILogger<RaceVar> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;
        }

        public async Task<IEnumerable<RaceVar>> GetAllRaceVar()
        {
            List<RaceVar> mylist = new List<RaceVar>();
            var list = await _DbContext.RaceVariant.ToListAsync();
            mylist = list;
            return mylist;
        }

        public async Task<IEnumerable<RaceVar>> GetAllRaceVarByRace(string charRace)
        {
            var mylist = await _DbContext.RaceVariant.Where(x => x.Race == charRace).ToListAsync();
            List<RaceVar> list = new List<RaceVar>();
            list = mylist;
            return list;
        }

        public async Task<RaceVar> GetRaceVarById(int id)
        {
            var raceVar = await _DbContext.RaceVariant.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (raceVar == null) { throw new Exception("Race Variant not found!"); }
            return raceVar;
        }

        public async Task UpdateRaceVar(RaceVar raceVar)
        {
            var oldraceVar = await _DbContext.RaceVariant.Where(x => x.Id == raceVar.Id).FirstOrDefaultAsync();
            if (oldraceVar != null)
            {
                oldraceVar.Str = raceVar.Str;
                oldraceVar.Dex = raceVar.Dex;
                oldraceVar.Con = raceVar.Con;
                oldraceVar.RaceInt = raceVar.RaceInt;
                oldraceVar.Wis = raceVar.Wis;
                oldraceVar.Cha = raceVar.Cha;
                oldraceVar.Pick = raceVar.Pick;
                oldraceVar.ManaBonus = raceVar.ManaBonus;
                oldraceVar.AddOrMultMana = raceVar.AddOrMultMana;
                oldraceVar.SpeedOverride = raceVar.SpeedOverride;

            }

            await _DbContext.SaveChangesAsync();
        }

    }


}

