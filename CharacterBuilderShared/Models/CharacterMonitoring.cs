using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace CharacterBuilderShared.Models
{

    public static class CharacterMonitoring
    {
        public static int interactivecounter { get; set; } = 0;
        public static int characterCounter { get; set; } = 0;
        public static int playerCounter { get; set; } = 0;
        public static int characterdeletecounter { get; set; } = 0;
        public static int characterupdatecounter { get; set; } = 0;
        public static int playerdeletecounter { get; set; } = 0;
        public static int playerupdatecounter { get; set; } = 0;
        public static int playerpagecounter { get; set; } = 0;
        public static int characterpagecounter { get; set; } = 0;
        public static int playercreationpagecounter { get; set; } = 0;
        public static int charactercreationpagecounter { get; set; } = 0;


        public static Meter meter { get; set; } = new("charactermetrics");
        public static string charactermetricstring = "I am a character trace";
        public static string playermetricstring = "I am a player trace";
        public static UpDownCounter<int> characterupDownCounter = meter.CreateUpDownCounter<int>("Charactercount", unit: "Characters", description: "Characters in total");
        public static UpDownCounter<int> playerupDownCounter = meter.CreateUpDownCounter<int>("Playercount", unit: "Players", description: "Players in total");
        public static ObservableCounter<int> observableCounter = meter.CreateObservableCounter<int>("apiviews", () => interactivecounter, unit: "views", "Api views?");
        public static ObservableCounter<int> observablecharacterdeleteCounter = meter.CreateObservableCounter<int>("CharactersDeleted", () => characterdeletecounter, unit: "characterdelete", "character deletes?");
        public static ObservableCounter<int> observablecharacterupdateCounter = meter.CreateObservableCounter<int>("CharactersUpdated", () => characterupdatecounter, unit: "characterupdate", "character updates?");
        public static ObservableCounter<int> observableplayerdeleteCounter = meter.CreateObservableCounter<int>("PlayersDeleted", () => playerdeletecounter, unit: "playerdelete", "player deletes?");
        public static ObservableCounter<int> observableplayerupdateCounter = meter.CreateObservableCounter<int>("PlayersUpdated", () => playerupdatecounter, unit: "playerupdate", "player updates?");


    }

}
