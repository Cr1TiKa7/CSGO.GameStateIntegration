using CSGO.GameStateIntegeration.State;

namespace CSGO.GameStateIntegeration.EventArgs
{
    public class OnRoundPhaseChangedEventArgs : System.EventArgs
    {
        /// <summary>
        /// Contains the state of the current round.
        /// </summary>
        public PhaseState RoundPhase { get; set; }
    }
}
