using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBuilderShared.Models
{
    public partial class Character
    {
        public Character()
        {
            CharName = string.Empty;
        }

        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string CharName { get; set; }
        public int? RaceId { get; set; }
        public int? RaceVariantId { get; set; }
        public int? ClassId { get; set; }
        public int? StatsId { get; set; }
        public int? ModStatsId { get; set; }
    }
}
