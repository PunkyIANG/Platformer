namespace Source.Utils
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        public static T Instance => _instance ?? Initialize();
        private static T _instance;
        private static readonly object InitLock = new object();

        private static T Initialize()
        {
            lock (InitLock)
            {
                // create new T and assign to _instance if null
                return _instance ??= new T();
            }
        }
    }
}