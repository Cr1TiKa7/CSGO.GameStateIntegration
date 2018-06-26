using Newtonsoft.Json;

namespace CSGO.GameStateIntegeration.ResponseObject
{
    public class State
    {
        public int Health { get; set; }
        public int Armor { get; set; }
        public bool Helmet { get; set; }
        public int Flashed { get; set; }
        public int Smoked { get; set; }
        public int Burning { get; set; }
        public int Money { get; set; }
        [JsonProperty(PropertyName = "round_kills")]
        public int RoundKills { get; set; }
        [JsonProperty(PropertyName = "round_killhs")]
        public int RoundKillhs { get; set; }
        [JsonProperty(PropertyName = "equip_value")]
        public int EquipValue { get; set; }
    }
}
