// See https://aka.ms/new-console-template for more information
using AdapterPattern;
using FactoryMethodPattern;
using SingletonPattern;

// SINGLETON PATTERN DEMO
CacheManager cacheManager = CacheManager.Instance;
cacheManager.AddToCache("MaxUsers", 100);

int? maxUsers = cacheManager.GetFromCache("MaxUsers") as int?;
CacheManager.Instance.AddToCache("MaxUsers", 100);

string? users = ConfigurationManager.Instance.GetConfigurations("MaxUsers");

Console.WriteLine($"Max Users: {maxUsers}");
Console.WriteLine($"Max Users: {users}");



// FACTORY METHOD PATTERN DEMO
ILogger consoleLogger = LoggerFactory.CreateLogger("Console");
consoleLogger.Log("This is a console log message.");

ILogger fileLogger = LoggerFactory.CreateLogger("File");
fileLogger.Log("This is a file log message.");

ILogger databaseLogger = LoggerFactory.CreateLogger("Database");
databaseLogger.Log("This is a database log message.");

ILogger cloudLogger = LoggerFactory.CreateLogger("Cloud");
cloudLogger.Log("This is a cloud log message.");


decimal amountToPay = 100.5M;

IPaymentGateway stripeGateway = PaymentGatewayFactory.CreatePaymentGateway("Stripe");
stripeGateway.ProcessPayment(amountToPay);

IPaymentGateway payPalGateway = PaymentGatewayFactory.CreatePaymentGateway("PayPal");
payPalGateway.ProcessPayment(amountToPay);

IPaymentGateway bankTransferGateway = PaymentGatewayFactory.CreatePaymentGateway("BankTransfer");
bankTransferGateway.ProcessPayment(amountToPay);

IPaymentGateway cryptoGateway = PaymentGatewayFactory.CreatePaymentGateway("Crypto");
cryptoGateway.ProcessPayment(amountToPay);



// ADAPTER PATTERN
IJsonWeatherProvider jsonService = new JsonWeatherService();
Console.WriteLine(jsonService.GetWeatherJson());

XmlWeatherService xmlWeatherService = new XmlWeatherService();
IJsonWeatherProvider adapter = new XmlToJsonWeatherAdapter(xmlWeatherService);
Console.WriteLine(adapter.GetWeatherJson());
