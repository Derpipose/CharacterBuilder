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


        public static Meter meter { get; set; } = new("charactermetrics");
        public static string charactermetricstring = "I am a character trace";
        public static string playermetricstring = "I am a player trace";
        public static UpDownCounter<int> characterupDownCounter = meter.CreateUpDownCounter<int>("Charactercount", unit: "Characters", description: "Characters in total");
        public static UpDownCounter<int> playerupDownCounter = meter.CreateUpDownCounter<int>("Playercount", unit: "Players", description: "Players in total");
        public static ObservableCounter<int> observableCounter = meter.CreateObservableCounter<int>("apiviews", () => interactivecounter, unit: "views", "Api views?");
        public static ObservableCounter<int> observablecharacterdeleteCounter = meter.CreateObservableCounter<int>("apiviews", () => characterdeletecounter, unit: "characterdelete", "character deletes?");
        public static ObservableCounter<int> observablecharacterupdateCounter = meter.CreateObservableCounter<int>("apiviews", () => characterupdatecounter, unit: "characterupdate", "character updates?");
        public static ObservableCounter<int> observableplayerdeleteCounter = meter.CreateObservableCounter<int>("apiviews", () => playerdeletecounter, unit: "playerdelete", "player deletes?");
        public static ObservableCounter<int> observableplayerupdateCounter = meter.CreateObservableCounter<int>("apiviews", () => playerupdatecounter, unit: "playerupdate", "player updates?");
        

    }

}
