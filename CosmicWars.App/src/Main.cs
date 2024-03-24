using Hwdtech;
using Hwdtech.Ioc;

using CosmicWars.Lib;

namespace CosmicWars.App
{
    class CosmicWarsApp
    {
        static void Main(string[] args)
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

            var startServerStrategy = new StartServerStrategy();
            IoC.Resolve<ICommand>("IoC.Register", "CosmicWars.App.Start", (object[] args) => (startServerStrategy.Execute(args))).Execute();

            var getThreadsCountStrategy = new GetThreadsCountStrategy();
            IoC.Resolve<ICommand>("IoC.Register", "CosmicWars.App.GetThreadsCount", (object[] args) => (getThreadsCountStrategy.Execute(args))).Execute();

            var createServerThreadsStrategy = new CreateServerThreadsStrategy();
            IoC.Resolve<ICommand>("IoC.Register", "CosmicWars.App.CreateServerThreads", (object[] args) => (createServerThreadsStrategy.Execute(args))).Execute();

            var stopServerStrategy = new StopServerStrategy();
            IoC.Resolve<ICommand>("IoC.Register", "CosmicWars.App.Stop", (object[] args) => (stopServerStrategy.Execute(args))).Execute();

            var threadsCount = IoC.Resolve<int>("CosmicWars.App.GetThreadsCount", args);
            var serverThreads = IoC.Resolve<List<ServerThread>>("CosmicWars.App.CreateServerThreads", threadsCount);
            IoC.Resolve<ICommand>("CosmicWars.App.Start", threadsCount, serverThreads).Execute();
        }
    }
}
