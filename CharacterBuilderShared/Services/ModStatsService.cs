using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class ModStatsService
    {
        private readonly ILogger<ModStats> _logger;
        private BuilderContext _DbContext;
        public ModStatsService(ILogger<ModStats> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;
        }

        public async Task<ModStats> GetModStats(int id)
        {
            var modStats = await _DbContext.ModifiedStats.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (modStats == null) { modStats = new ModStats(); }
            return modStats;
        }

        public async Task AddModStats(ModStats modStats)
        {
            if (modStats != null)
            {
                _DbContext.ModifiedStats.Add(modStats);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateModStats(ModStats modStats)
        {
            var oldmodStats = await _DbContext.ModifiedStats.Where(x => x.Id == modStats.Id).FirstOrDefaultAsync();
            if (oldmodStats != null)
            {
                oldmodStats.ModStr = modStats.ModStr;
                oldmodStats.ModDex = modStats.ModDex;
                oldmodStats.ModCon = modStats.ModCon;
                oldmodStats.ModInt = modStats.ModInt;
                oldmodStats.ModWis = modStats.ModWis;
                oldmodStats.ModCha = modStats.ModCha;
            }
        }

        public async Task DeleteModStats(int id)
        {
            var modStats = await _DbContext.ModifiedStats.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (modStats != null)
            {
                _DbContext.ModifiedStats.Remove(modStats);
            }
            await _DbContext.SaveChangesAsync();
        }

    }
}
