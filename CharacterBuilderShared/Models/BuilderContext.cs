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
        public DbSet<Character> CharacterSet { get; set; }
        public DbSet<CharClass> CharClassSet { get; set; }
        public DbSet<CharRace> CharRaceSet { get; set; }
        public DbSet<ModStats> ModStatsSet { get; set; }
        public DbSet<Player> PlayerSet { get; set; }
        public DbSet<RaceVar> RaceVarSet { get; set; }
        public DbSet<Stats> StatsSet { get; set; }
        public BuilderContext()
        {

        }
    }
}
