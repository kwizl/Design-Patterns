namespace SingletonPattern
{
    public sealed class ConfigurationManager
    {
        // Static member are lazily intialized
        // .NET guarantees thread safety for static initialization
        private static readonly Lazy<ConfigurationManager> lazyInstance = new Lazy<ConfigurationManager>(() => new ConfigurationManager());

        private Dictionary<string, string> configurations;
        public static ConfigurationManager Instance => lazyInstance.Value;

        // Private constructor to prevent instantiation
        private ConfigurationManager()
        {
            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            configurations = new Dictionary<string, string>
            {
                { "AppName", "SingletonApp" },
                { "Version", "1.0.0" },
                { "MaxUsers", "100" }
            };
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"Log {message}");
        }

        public string? GetConfigurations(string key)
        {
            configurations.TryGetValue(key, out string? value);
            return value;
        }

    }
}
