using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public partial class CharRace
    {
        public CharRace()
        {
            Campaign = "";
            SubType = "";
            RaceName = "";
            RaceDescription = "";
            Starter = "";
            Special = "";
            Pick = "";
            AddOrMultMana = "";
            Languages = "";
        }
        public int Id { get; set; }
        public string Campaign { get; set; }
        public string SubType { get; set; }
        public string RaceName { get; set; }
        public string RaceDescription { get; set; }
        public string Starter { get; set; }
        public string Special { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Wis { get; set; }
        public int Int { get; set; }
        public int Cha { get; set; }
        public string Pick { get; set; }
        public int BonusMana { get; set; }
        public string AddOrMultMana { get; set; }
        public int? Speed { get; set; }
        public string Languages { get; set; }
    }
}
