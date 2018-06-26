using Newtonsoft.Json;

namespace CSGO.GameStateIntegeration.ResponseObject
{
    public class Player
    {
        public string SteamId { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName ="observer_slot")]
        public int ObserverSlot { get; set; }
        public string Team { get; set; }
        public string Activity { get; set; }
        /// <summary>
        /// Not working at the moment.
        /// </summary>
        public object Weapons { get; set; }
        [JsonProperty(PropertyName = "match_stats")]
        public MatchStats MatchStats { get; set; }
        public State State { get; set; }
    }
}
