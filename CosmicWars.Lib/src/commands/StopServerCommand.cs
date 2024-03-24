using Hwdtech;

namespace CosmicWars.Lib
{
    class StopServerCommand : ICommand
    {
        List<ServerThread> _serverThreads;

        public StopServerCommand(List<ServerThread> serverThreads)
        {
            _serverThreads = serverThreads;
        }

        public void Execute()
        {
            foreach (var serverThread in _serverThreads)
            {
                serverThread.Stop();
            }
            Console.WriteLine("[+] Server is stopped!");
        }
    }
}
