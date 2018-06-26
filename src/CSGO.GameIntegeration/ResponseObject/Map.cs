using Newtonsoft.Json;

namespace CSGO.GameStateIntegeration.ResponseObject
{
    public class Map
    {
        public string Mode { get; set; }
        public string Name { get; set; }
        public string Phase { get; set; }
        public int Round { get; set; }
        [JsonProperty(PropertyName = "team_ct")]
        public Team TeamCt { get; set; }
        [JsonProperty(PropertyName = "team_t")]
        public Team TeamT { get; set; }
        [JsonProperty(PropertyName = "num_matches_to_win_series")]
        public int NumMatchesToWinSeries { get; set; }
        [JsonProperty(PropertyName = "current_spectators")]
        public int CurrentSpectators { get; set; }
        [JsonProperty(PropertyName = "souvenirs_total")]
        public int SouvenirsTotal { get; set; }
    }
}
