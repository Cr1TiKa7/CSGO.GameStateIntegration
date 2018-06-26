using CSGO.GameStateIntegeration;

namespace CSGO.GameStateIntegration.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStateListener listener = new GameStateListener("http://localhost:1337/");
            listener.Connect();

            while (true)
            {
                
            }
        }
    }
}
