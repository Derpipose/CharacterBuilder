using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public partial class Stats
    {

        public Stats()
        {


        }

        public int Id { get; set; }
        public int BaseStr { get; set; }
        public int BaseDex { get; set; }
        public int BaseCon { get; set; }
        public int BaseInt { get; set; }
        public int BaseWis { get; set; }
        public int BaseCha { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int CharLevel { get; set; } = 1;
    }
}
