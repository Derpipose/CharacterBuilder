namespace CharacterBuilderShared.Models
{
    public partial class CharClass
    {
        public CharClass()
        {

            Classification = "";
            ClassName = "";
            Description = "";
            Starter = "";
            SpellCastingModifier = "";
            StatFavor1 = "";
            StatFavor2 = "";
            ClassSpecific = "";
            ProficiencyStart = "";
            VeteranTag = "";
        }
        public int Id { get; set; }
        public string Classification { get; set; }
        public string ClassName { get; set; }
        public int HitDie { get; set; }
        public int ManaDie { get; set; }
        public int ProficiencyCount { get; set; }
        public int MagicBooks { get; set; }
        public int Cantrips { get; set; }
        public int Chances { get; set; }
        public string Description { get; set; }
        public string Starter { get; set; }
        public string SpellCastingModifier { get; set; }
        public string StatFavor1 { get; set; }
        public string StatFavor2 { get; set; }
        public string ClassSpecific { get; set; }
        public int LanguageCount { get; set; }
        public string ProficiencyStart { get; set; }
        public string VeteranTag { get; set; }
    }
}
