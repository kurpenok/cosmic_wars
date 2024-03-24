using Hwdtech;

namespace CosmicWars.Lib
{
    public class StartServerCommand : ICommand
    {
        private bool _running;
        private int _threadsCount;
        private List<ServerThread> _serverThreads;
        private Dictionary<int, ServerThread> _serverThreadQueues;

        public StartServerCommand(int threadsCount, List<ServerThread> serverThreads)
        {
            _running = true;
            _threadsCount = threadsCount;
            _serverThreads = serverThreads;
            _serverThreadQueues = new Dictionary<int, ServerThread>();
        }

        public void Execute()
        {
            Console.WriteLine("[+] Server is running!");

            for (int i = 0; i < _threadsCount; i++)
            {
                _serverThreadQueues.Add(i, _serverThreads[i]);
                _serverThreads[i].Start();
            }

            while (_running)
            {
                // true for suppressing character output
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Q)
                {
                    _running = false;
                    IoC.Resolve<ICommand>("CosmicWars.App.Stop", _serverThreads).Execute();
                }
            }
        }
    }
}
