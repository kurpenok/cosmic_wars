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

            IoC.Resolve<ICommand>("CosmicWars.App.Start", IoC.Resolve<int>("CosmicWars.App.GetThreadsCount", args)).Execute();
        }
    }
}
