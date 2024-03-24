namespace CosmicWars.Lib
{
    public class StopServerStrategy : IStrategy
    {
        public object Execute(params object[] args)
        {
            var serverThreads = (List<ServerThread>)args[0];

            return new StopServerCommand(serverThreads);
        }
    }
}
