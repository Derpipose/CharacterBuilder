using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class StatsService
    {
        private readonly ILogger<Stats> _logger;
        private BuilderContext _DbContext;
        public StatsService(ILogger<Stats> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;
        }

        public async Task<IEnumerable<Stats>> GetAllStats()
        {
            var stats = await _DbContext.CharacterStats.ToListAsync();
            List<Stats> statsList = new List<Stats>();
            statsList = stats;
            return statsList;
        }

        public async Task<Stats> GetStatsById(int id)
        {
            var stats = await _DbContext.CharacterStats.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (stats == null) { stats = new Stats(); }
            return stats;
        }

        public async Task AddStats(Stats stats)
        {
            if (stats != null)
            {
                _DbContext.CharacterStats.Add(stats);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStats(Stats stats)
        {
            var oldstats = await _DbContext.CharacterStats.Where(x => x.Id == stats.Id).FirstOrDefaultAsync();
            if (oldstats != null)
            {
                oldstats.BaseStr = stats.BaseStr;
                oldstats.BaseDex = stats.BaseDex;
                oldstats.BaseCon = stats.BaseCon;
                oldstats.BaseInt = stats.BaseInt;
                oldstats.BaseWis = stats.BaseWis;
                oldstats.BaseCha = stats.BaseCha;
                oldstats.Health = stats.Health;
                oldstats.Mana = stats.Mana;
                oldstats.CharLevel = stats.CharLevel;
            }
            await _DbContext.SaveChangesAsync();
        }

        public async Task DeleteStats(int id)
        {
            var stats = await _DbContext.CharacterStats.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (stats != null)
            {
                _DbContext.CharacterStats.Remove(stats);
            }
            await _DbContext.SaveChangesAsync();
        }


    }
}
