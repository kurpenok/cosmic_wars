using System.CommandLine;
using System.Threading;

namespace CosmicWars.App {
    class ConsoleThread {
        public bool running;
        public Thread thread;

        public ConsoleThread() {
            this.running = true;
            this.thread = new Thread(() => TestFunction(running));
        }

        public void Start() {
            this.thread.Start();

            Console.WriteLine($"[+] Thread running");

            Stop();
        }

        public void Stop() {
            this.thread.Join();
        }

        void TestFunction(bool running) {
            Console.WriteLine($"[+] Message by thread: {running}");
        }
    }

    class MutliThreadedConsoleApp {
        static async Task Main(string[] args) {
            var rootCommand = new RootCommand();

            var threadsCount = 1;
            var threadsCountOption = new Option<int>(
                name: "--threads-count",
                description: "Creates a stream count equal to the number passed to the parameters.",
                getDefaultValue: () => 1);
            threadsCountOption.AddAlias("-t");
            rootCommand.AddOption(threadsCountOption);

            rootCommand.SetHandler((threadsCountOptionValue) => {
                threadsCount = threadsCountOptionValue;
                Console.WriteLine($"[+] Count of threads: {threadsCount}");
                Console.WriteLine($"[+] For exit press q...");
            }, threadsCountOption);
            await rootCommand.InvokeAsync(args);

            ConsoleThread[] threads = new ConsoleThread[threadsCount];
            for (int i = 0; i < threadsCount; i++) {
                threads[i] = new ConsoleThread();
            }

            for (int i = 0; i < threadsCount; i++) {
                threads[i].Start();
            }

            while (true) {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q) {
                    for (int i = 0; i < threadsCount; i++) {
                        threads[i].running = false;
                    }
                    break;
                }
            }
        }
    }
}
