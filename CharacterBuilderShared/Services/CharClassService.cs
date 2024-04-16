using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class CharClassService
    {
        private readonly ILogger<CharClass> _logger;
        private BuilderContext _DbContext;
        public CharClassService(ILogger<CharClass> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;
        }

        public async Task<IEnumerable<CharClass>> GetAllCharClasses()
        {
            var list = await _DbContext.CharacterClass.ToListAsync();
            List<CharClass> mylist = new List<CharClass>();
            mylist = list;
            return mylist;
        }

        public async Task<IEnumerable<CharClass>> GetAllCharClassByType(string type)
        {
            var list = await _DbContext.CharacterClass.Where(x => x.Classification == type).ToListAsync();
            var mylist = new List<CharClass>();
            mylist = list;
            return mylist;
        }

        public async Task<CharClass> GetCharClassById(int id)
        {
            var charclass = await _DbContext.CharacterClass.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (charclass == null) { throw new Exception("Class not found!"); }
            return charclass;

        }

        public async Task UpdateClass(CharClass charclass)
        {
            var oldcharclass = await _DbContext.CharacterClass.Where(x => x.Id == charclass.Id).FirstOrDefaultAsync();
            if (oldcharclass != null)
            {
                oldcharclass.HitDie = charclass.HitDie;
                oldcharclass.ManaDie = charclass.ManaDie;
                oldcharclass.ProficiencyCount = charclass.ProficiencyCount;
                oldcharclass.MagicBooks = charclass.MagicBooks;
                oldcharclass.Cantrips = charclass.Cantrips;
                oldcharclass.Chances = charclass.Chances;
                oldcharclass.Description = charclass.Description;
                oldcharclass.Starter = charclass.Starter;
                oldcharclass.SpellCastingModifier = charclass.SpellCastingModifier;
                oldcharclass.StatFavor1 = charclass.StatFavor1;
                oldcharclass.StatFavor2 = charclass.StatFavor2;
                oldcharclass.ClassSpecific = charclass.ClassSpecific;
                oldcharclass.LanguageCount = charclass.LanguageCount;
                oldcharclass.VeteranTag = charclass.VeteranTag;
            }
            await _DbContext.SaveChangesAsync();

        }

    }
}
