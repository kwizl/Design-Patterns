// See https://aka.ms/new-console-template for more information
using SingletonPattern;

CacheManager cacheManager = CacheManager.Instance;
cacheManager.AddToCache("MaxUsers", 100);

int? maxUsers = cacheManager.GetFromCache("MaxUsers") as int?;
CacheManager.Instance.AddToCache("MaxUsers", 100);

string? users = ConfigurationManager.Instance.GetConfigurations("MaxUsers");

Console.WriteLine($"Max Users: {maxUsers}");
Console.WriteLine($"Max Users: {users}");
