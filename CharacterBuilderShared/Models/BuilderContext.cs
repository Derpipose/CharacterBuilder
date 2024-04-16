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
        public DbSet<Character> PlayerCharacter => Set<Character>();
        public DbSet<CharClass> CharacterClass => Set<CharClass>();
        public DbSet<CharRace> CharacterRace => Set<CharRace>();
        public DbSet<ModStats> ModifiedStats => Set<ModStats>();
        public DbSet<Player> Player => Set<Player>();
        public DbSet<RaceVar> RaceVariant => Set<RaceVar>();
        public DbSet<Stats> CharacterStats => Set<Stats>();
        public BuilderContext(DbContextOptions<BuilderContext> options) : base(options)
        {

        }
    }
}
