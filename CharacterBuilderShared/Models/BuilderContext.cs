using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CharacterBuilderShared.Models
{
    public class BuilderContext : DbContext
    {
        public DbSet<Character> CharacterSet => Set<Character>();
        public DbSet<CharClass> CharClassSet => Set<CharClass>();
        public DbSet<CharRace> CharRaceSet => Set<CharRace>();
        public DbSet<ModStats> ModStatsSet => Set<ModStats>();
        public DbSet<Player> PlayerSet => Set<Player>();
        public DbSet<RaceVar> RaceVarSet => Set<RaceVar>();
        public DbSet<Stats> StatsSet => Set<Stats>();
        public BuilderContext(DbContextOptions<BuilderContext> options) : base(options)
        {

        }
    }
}
