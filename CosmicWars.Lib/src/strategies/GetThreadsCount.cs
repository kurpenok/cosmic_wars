namespace CosmicWars.Lib
{
    public class GetThreadsCountStrategy : IStrategy
    {
        public object Execute(params object[] args)
        {
            var shellArgs = (string[])args;

            if ((shellArgs.Length == 2) && ((shellArgs[0] == "-t") || (shellArgs[0] == "--threads-count")))
            {
                if (int.TryParse(shellArgs[1], out int threadsCount))
                {
                    return threadsCount;
                }
            }

            return 0;
        }
    }
}
