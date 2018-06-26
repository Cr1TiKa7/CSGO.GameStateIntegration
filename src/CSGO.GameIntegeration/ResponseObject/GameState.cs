namespace CSGO.GameStateIntegeration.ResponseObject
{
    public class GameState
    {
        public Provider Provider { get; set; }
        public Map Map { get; set; }
        public Round Round { get; set; }
        public Player Player { get; set; }
    }
}
