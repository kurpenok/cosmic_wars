namespace CosmicWars.Lib
{
    public class CreateServerThreadsStrategy : IStrategy
    {
        public object Execute(params object[] args)
        {
            List<ServerThread> serverThreads = new List<ServerThread>();
            int threadsCount = (int)args[0];

            for (int i = 0; i < threadsCount; i++)
            {
                var serverThread = new ServerThread();
                serverThreads.Add(serverThread);
            }

            return serverThreads;
        }
    }
}
