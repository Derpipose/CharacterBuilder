using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public partial class Player
    {
        public Player()
        {
            PlayerName = "";
            Username = string.Empty;
            Veteran = false;
        }

        public int Id { get; set; }
        public string PlayerName { get; set; }
        public bool Veteran { get; set; }
        public string Username { get; set; }
        public int Pin { get; set; }

    }
}
