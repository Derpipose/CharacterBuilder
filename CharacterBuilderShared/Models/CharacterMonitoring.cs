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
        public static int charactercreatecounter { get; set; } = 0;
        public static int playercreatecounter { get; set; } = 0;
        public static int homepagecounter { get; set; } = 0;    


        public static Meter meter { get; set; } = new("charactermetrics");
        public static string charactermetricstring = "I am a character trace";
        public static string playermetricstring = "I am a player trace";
        public static UpDownCounter<int> characterupDownCounter = meter.CreateUpDownCounter<int>("charactercount", description: "Characters_Made_Since_last_reset_total");
        public static UpDownCounter<int> playerupDownCounter = meter.CreateUpDownCounter<int>("playercount", description: "Characters_Made_Since_last_reset_total");
        public static ObservableCounter<int> observableCounter = meter.CreateObservableCounter<int>("apiviews", () => interactivecounter, "api_views_total");
        public static ObservableCounter<int> observablecharactercreateCounter = meter.CreateObservableCounter<int>("characterscreated", () => charactercreatecounter, "character_created_total");
        public static ObservableCounter<int> observablecharacterdeleteCounter = meter.CreateObservableCounter<int>("charactersdeleted", () => characterdeletecounter, "character_deleted_total");
        public static ObservableCounter<int> observablecharacterupdateCounter = meter.CreateObservableCounter<int>("charactersupdated", () => characterupdatecounter, "character_updated_total");
        public static ObservableCounter<int> observableplayercreateCounter = meter.CreateObservableCounter<int>("playerscreated", () => playercreatecounter, "player_created_total");
        public static ObservableCounter<int> observableplayerdeleteCounter = meter.CreateObservableCounter<int>("playersdeleted", () => playerdeletecounter, "player_deleted_total");
        public static ObservableCounter<int> observableplayerupdateCounter = meter.CreateObservableCounter<int>("playersupdated", () => playerupdatecounter, "player_updated_total");
        public static ObservableCounter<int> observablehomepageCounter = meter.CreateObservableCounter<int>("homepage", () => homepagecounter, "homepageviews_total");
        public static ObservableCounter<int> observableplayerpageCounter = meter.CreateObservableCounter<int>("playerpage", () => playerpagecounter, "playerpageviews_total");
        public static ObservableCounter<int> observablecharacterpageCounter = meter.CreateObservableCounter<int>("characterpage", () => characterpagecounter, "characterpageviews_total");


    }

}
