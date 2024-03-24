namespace CosmicWars.Lib
{
    public class StartServerStrategy : IStrategy
    {
        public object Execute(params object[] args)
        {
            var threadsCount = (int)args[0];
            var serverThreads = (List<ServerThread>)args[1];

            return new StartServerCommand(threadsCount, serverThreads);
        }
    }
}
