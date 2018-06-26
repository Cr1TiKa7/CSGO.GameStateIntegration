using System;
using System.IO;
using System.Net;
using System.Threading;
using CSGO.GameStateIntegeration.EventArgs;
using CSGO.GameStateIntegeration.ResponseObject;
using Newtonsoft.Json;

namespace CSGO.GameStateIntegeration
{
    public class GameStateListener
    {
        private HttpListener _HttpListener;
        private GameState _LatestGameState;
        /// <summary>
        /// Contains the latest received game state.
        /// </summary>
        public GameState GameState => _LatestGameState;

        private readonly string _Prefix;
        private bool _IsRunning = false;
        public bool IsRunning => _IsRunning;

        public EventHandler<OnNewGameStateEventArgs> OnNewGameState;
        public EventHandler<OnPlayerFlashedEventArgs> OnPlayerFlashed;
        public EventHandler<OnPlayerDamagedEventArgs> OnPlayerDamaged;
        public EventHandler<OnRoundPhaseChangedEventArgs> OnRoundPhaseChanged;
        public EventHandler<OnBombStateChangedEventArgs> OnBombStateChanged;
        public EventHandler<OnTeamWinsEventArgs> OnTeamWins;

        public GameStateListener()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix">The url the listener should listen to.</param>
        public GameStateListener(string prefix)
        {
            _Prefix = prefix;
        }

        /// <summary>
        /// Starts listening to the given url.
        /// </summary>
        public void Connect()
        {
            Connect(_Prefix);
        }

        /// <summary>
        /// Starts listening to the given url.
        /// </summary>
        /// <param name="prefix">The url the listener should listen to.</param>
        public void Connect(string prefix)
        {
            try
            {
                _HttpListener = new HttpListener();
                _HttpListener.Prefixes.Add(prefix);
                _HttpListener.Start();

                Thread _HttpListenerThread = new Thread(Listener);
                _HttpListenerThread.Start();
                _IsRunning = true;
            }
            catch (Exception ex)
            {
                //TODO: Throw exception
                _IsRunning = false;
            }
        }

        private void Listener()
        {
            while (_IsRunning)
            {
                var context = _HttpListener.GetContext();
                var request = context.Request;

                GameState gameState = null;

                using (Stream responseStream = request.InputStream)
                {
                    using (StreamReader streamReader = new StreamReader(responseStream))
                    {
                        string json = streamReader.ReadToEnd();
                        if (!string.IsNullOrEmpty(json))
                        {
                            gameState = JsonConvert.DeserializeObject<GameState>(json);
                        }
                    }
                }

                //Invoke events if the gamestate is not null.
                if (gameState != null)
                {
                    //New game state received
                    OnNewGameState?.Invoke(this, new OnNewGameStateEventArgs
                    {
                        GameState = gameState
                    });

                    //Player is flashed.
                    if (gameState.Player.State.Flashed > 0)
                        OnPlayerFlashed?.Invoke(this, new OnPlayerFlashedEventArgs
                        {
                             Flashed = gameState.Player.State.Flashed
                        });

                    //Player got damage
                    if (_LatestGameState?.Player.State.Health > gameState.Player.State.Health ||
                        _LatestGameState?.Player.State.Armor > gameState.Player.State.Armor)
                        OnPlayerDamaged?.Invoke(this, new OnPlayerDamagedEventArgs
                        {
                            Armor = gameState.Player.State.Armor,
                            Health = gameState.Player.State.Health
                        });

                    //Bombstate changed
                    if (_LatestGameState?.Round.Bomb != gameState.Round.Bomb && gameState.Round.Bomb != State.BombState.Undefined)
                        OnBombStateChanged?.Invoke(this, new OnBombStateChangedEventArgs
                        {
                            BombState = gameState.Round.Bomb
                        });

                    //Roundstate changed
                    if (_LatestGameState?.Round.Phase != gameState.Round.Phase && gameState.Round.Phase !=  State.PhaseState.Undefined)
                        OnRoundPhaseChanged?.Invoke(this, new OnRoundPhaseChangedEventArgs
                        {
                             RoundPhase = gameState.Round.Phase
                        });

                    //Bombstate changed
                    if (_LatestGameState?.Round.WinTeam != gameState.Round.WinTeam && gameState.Round.WinTeam != State.TeamType.Undefined)
                        OnBombStateChanged?.Invoke(this, new OnBombStateChangedEventArgs
                        {
                            BombState = gameState.Round.Bomb
                        });

                    if (gameState.Player.MatchStats.Kills > _LatestGameState?.Player.MatchStats.Kills)
                        Console.WriteLine("Kill");

                    _LatestGameState = gameState;
                }

            }
        }

    }
}
