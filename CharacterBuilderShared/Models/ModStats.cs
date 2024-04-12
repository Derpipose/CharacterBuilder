using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public partial class ModStats
    {
        public ModStats()
        {

        }
        public int Id { get; set; }
        public int ModStr { get; set; }
        public int ModDex { get; set; }
        public int ModCon { get; set; }
        public int ModInt { get; set; }
        public int ModWis { get; set; }
        public int ModCha { get; set; }
    }
}
