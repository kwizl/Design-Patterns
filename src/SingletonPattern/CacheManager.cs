namespace SingletonPattern
{
    public sealed class CacheManager
    {
        // Static member are lazily intialized
        // .NET guarantees thread safety for static initialization
        private static readonly Lazy<CacheManager> lazyInstance = new Lazy<CacheManager>(() => new CacheManager());

        private Dictionary<string, object> cacheStore;
        public static CacheManager Instance => lazyInstance.Value;

        // Private constructor to prevent instantiation
        private CacheManager()
        {
            cacheStore = new Dictionary<string, object>();
        }

        public void AddToCache(string key, object value)
        {
            if (!cacheStore.ContainsKey(key))
                cacheStore[key] = value;
        }

        public object? GetFromCache(string key)
        {
            cacheStore.TryGetValue(key, out var value);
            return value;
        }

        public void RemoveFromCache(string key)
        {
            if (!cacheStore.ContainsKey(key))
                cacheStore.Remove(key);
        }
    }
}
