namespace CosmicWars.Lib
{
    public class GetThreadsCountStrategy : IStrategy
    {
        public object Execute(params object[] args)
        {
            var _args = (string[])args;

            if ((_args.Length == 2) && ((_args[0] == "-t") || (_args[0] == "--threads-count")))
            {
                if (int.TryParse(_args[1], out int threadsCount))
                {
                    return threadsCount;
                }
            }

            return 0;
        }
    }
}
