using Newtonsoft.Json;

namespace CSGO.GameStateIntegeration.ResponseObject
{
    public class Team
    {
        public int Score { get; set; }
        [JsonProperty(PropertyName = "timeouts_remaining")]
        public int TimeoutsRemaining { get; set; }
        [JsonProperty(PropertyName = "matches_won_this_series")]
        public int MatchesWonThisSeries { get; set; }
    }
}
