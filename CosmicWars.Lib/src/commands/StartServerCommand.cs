using Hwdtech;

namespace CosmicWars.Lib
{
    public class StartServerCommand : ICommand
    {
        private bool _running;
        private int _threadsCount;

        public StartServerCommand(int threadsCount)
        {
            _running = true;
            _threadsCount = threadsCount;
        }

        public void Execute()
        {
            Console.WriteLine("[+] Server is running!");
            Console.WriteLine($"[+] Server threads count: {_threadsCount}");

            while (_running)
            {
                // true for suppressing character output
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Q)
                {
                    _running = false;
                    Console.WriteLine("[+] Server is stopped!");
                }
            }
        }
    }
}
