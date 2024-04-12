using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<IEnumerable<Character>> GetAll()
        {
            return await _DbContext.GetAll();
        }

    }
}
