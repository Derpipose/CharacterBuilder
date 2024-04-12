using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public partial class RaceVar
    {
        public RaceVar()
        {
            Race = string.Empty;
            Variant = string.Empty; 
            Pick = string.Empty;
            AddOrMultMana = string.Empty;  
        }
        public int Id { get; set; }
        public string Race { get; set; }
        public string Variant { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        public string Pick { get; set; }
        public int ManaBonus { get; set; }
        public string AddOrMultMana { get; set; }
        public int SpeedOverride { get; set; }
    }
}
