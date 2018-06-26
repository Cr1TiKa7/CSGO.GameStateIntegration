using Newtonsoft.Json;

namespace CSGO.GameStateIntegeration.ResponseObject
{
    public class Round
    {
        public string Phase { get; set; }
        [JsonProperty(PropertyName = "win_team")]
        public string WinTeam { get; set; }
    }
}
