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

        private void ThreadHandle() {
            Console.WriteLine("[+] Thread is running!");
        }
    }
}
