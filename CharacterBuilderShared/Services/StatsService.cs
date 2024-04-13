using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumberable<Stats>> GetAllStats()
        {
            var stats = await _DbContext.StatsSet.ToListAsync();
            List<Stats> statsList = new List<Stats>();
            statsList = stats;
            return statsList;
        }

        public async Task GetStatsById(int id)
        {
            var stats = await _DbContext.StatsSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            return stats;
        }

        public async Task AddStats(Stats stats)
        {
            if (stats != null)
            {
                _DbContext.StatsSet.Add(stats);
                await _DbContext.StatsSet.SaveChangesAsync();
            }
        }

        public async Task UpdateStats(Stats stats)
        {
            var oldstats = await _DbContext.StatsSet.Where(x => x.Id == id).FirstOrDefaultAsync();
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
            await _DbContext.StatsSet.SaveChangesAsync()
        }

        public async Task DeleteStats(int id)
        {
            var stats = await _DbContext.StatsSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (stats != null)
            {
                _DbContext.StatsSet.Remove(stats);
            }
            await _DbContext.SaveChangesAsync();
        }


    }
}
