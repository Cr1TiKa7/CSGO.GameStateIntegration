using CSGO.GameStateIntegeration.State;
using Newtonsoft.Json;

namespace CSGO.GameStateIntegeration.ResponseObject
{
    public class Round
    {
        public PhaseState Phase { get; set; }
        [JsonProperty(PropertyName = "win_team")]
        public TeamType WinTeam { get; set; }
        public BombState Bomb { get; set; }
    }
}
