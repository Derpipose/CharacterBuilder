using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public partial class ModStatsService
    {
        private readonly ILogger<ModStats> _logger;
        private BuilderContext _DbContext;
        public ModStatsService(ILogger<ModStats> logger, BuilderContext buildercontext)
        {
            _logger = logger;
            _DbContext = buildercontext
        }

    }
}
