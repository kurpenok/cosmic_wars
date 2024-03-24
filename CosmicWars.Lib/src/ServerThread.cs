using System.Collections.Concurrent;

using Hwdtech;

namespace CosmicWars.Lib
{
    public class ServerThread
    {
        private ConcurrentQueue<ICommand> _command_queue;
        private Thread _thread;

        public ServerThread()
        {
            _command_queue = new ConcurrentQueue<ICommand>();
            _thread = new Thread(ThreadHandle);
        }

        public void Start()
        {
            _thread.Start();
        }

        public void Stop()
        {
            _thread.Join();
        }

        private void ThreadHandle()
        {
            // Simulation thread work
            // There should be command execution here
            Console.WriteLine("[+] Thread is running!");
        }
    }
}
