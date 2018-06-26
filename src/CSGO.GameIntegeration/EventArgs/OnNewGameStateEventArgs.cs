using CSGO.GameStateIntegeration.ResponseObject;

namespace CSGO.GameStateIntegeration.EventArgs
{
    public class OnNewGameStateEventArgs : System.EventArgs
    {
        public GameState GameState { get; set; }
    }
}
