using System;
using CSGO.GameStateIntegeration;
using CSGO.GameStateIntegeration.EventArgs;

namespace CSGO.GameStateIntegration.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStateListener listener = new GameStateListener("http://localhost:1337/");
            listener.OnNewGameState += OnNewGameState;
            listener.OnBombStateChanged += OnBombStateChanged;
            listener.OnPlayerDamaged += OnPlayerDamaged;
            listener.OnPlayerFlashed += OnPlayerFlashed;
            listener.OnRoundPhaseChanged += OnRoundPhaseChanged;

            listener.Connect();

            while (true)
            {
                
            }
        }

        private static void OnNewGameState(object sender, OnNewGameStateEventArgs e)
        {
        }

        private static void OnBombStateChanged(object sender, OnBombStateChangedEventArgs e)
        {
            Console.WriteLine("Bombstate changed to: " + e.BombState);
        }

        private static void OnPlayerDamaged(object sender, OnPlayerDamagedEventArgs e)
        {
            Console.WriteLine("Player damaged. Health " + e.Health +" | Armor: " + e.Armor);
        }

        private static void OnPlayerFlashed(object sender, OnPlayerFlashedEventArgs e)
        {
            Console.WriteLine("Player was flashed: " + e.Flashed);
        }

        private static void OnRoundPhaseChanged(object sender, OnRoundPhaseChangedEventArgs e)
        {
            Console.WriteLine("Roundphase changed to: " + e.RoundPhase);
        }

    }
}
