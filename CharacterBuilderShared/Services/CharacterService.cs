using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterBuilderShared.Models
{
    public partial class CharacterService
    {
        private readonly ILogger<Character> _logger;
        private BuilderContext _DbContext;
        public CharacterService(ILogger<Character> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext;
        }


        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            var mylist = await _DbContext.CharacterSet.ToListAsync();
            List<Character> list = new List<Character>();
            list = mylist;
            return list;
        }

        public async Task<IEnumerable<Character>> GetAllCharactersByPlayer(int id)
        {
            var mylist = await _DbContext.CharacterSet.Where(x => x.PlayerId == id).ToListAsync();
            List<Character> list = new List<Character>();
            list = mylist;
            return list;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _DbContext.CharacterSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (character == null) { character = new Character(); }
            Character character1 = character;
            return character1;
        }

        public async Task AddCharacter(Character character)
        {
            if (character != null)
            {
                _DbContext.CharacterSet.Add(character);
                await _DbContext.SaveChangesAsync();
            }
            // else{
            //     throw new Exception ("Character not defined properly");
            // }
        }

        public async Task DeleteCharacter(int id)
        {
            var character = await _DbContext.CharacterSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (character != null)
            {
                _DbContext.CharacterSet.Remove(character);
                await _DbContext.SaveChangesAsync();
            }

        }

        public async Task UpdateCharacter(Character character)
        {
            var oldcharacter = await _DbContext.CharacterSet.Where(x => x.Id == character.Id).FirstOrDefaultAsync();
            if (oldcharacter != null)
            {
                oldcharacter.CharName = character.CharName;
                oldcharacter.RaceId = character.RaceId;
                oldcharacter.RaceVariantId = character.RaceVariantId;
                oldcharacter.StatId = character.StatId;
                oldcharacter.ModStatId = character.ModStatId;
            }

            await _DbContext.SaveChangesAsync();
        }

    }
}
