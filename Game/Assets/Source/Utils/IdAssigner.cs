namespace Source.Utils
{
    /// <summary>
    /// Assigns a unique id for whatever shenanigans you might need, be it entity or attack ids.
    /// </summary>
    public class IdAssigner : Singleton<IdAssigner>
    {
        private uint _maxId;
        private readonly object _incrementLock = new object();

        public uint GetId()
        {
            lock (_incrementLock)
                return _maxId++;
        }
    }
}