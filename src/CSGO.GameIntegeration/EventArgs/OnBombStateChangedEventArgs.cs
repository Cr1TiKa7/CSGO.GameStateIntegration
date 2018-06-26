using CSGO.GameStateIntegeration.State;

namespace CSGO.GameStateIntegeration.EventArgs
{
    public class OnBombStateChangedEventArgs : System.EventArgs
    {
        /// <summary>
        /// Contains the current state of the bomb.
        /// </summary>
        public BombState BombState { get; set; }
    }
}
