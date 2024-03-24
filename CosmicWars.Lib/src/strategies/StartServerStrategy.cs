namespace CosmicWars.Lib
{
    public class StartServerStrategy : IStrategy
    {
        public object Execute(params object[] args)
        {
            var _threadsCount = (int)args[0];

            return new StartServerCommand(_threadsCount);
        }
    }
}
