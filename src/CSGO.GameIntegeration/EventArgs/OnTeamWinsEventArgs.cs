using CSGO.GameStateIntegeration.State;

namespace CSGO.GameStateIntegeration.EventArgs
{
    public class OnTeamWinsEventArgs : System.EventArgs
    {
        /// <summary>
        /// Contains the team that won the round.
        /// </summary>
        public TeamType Team { get; set; }
    }
}
