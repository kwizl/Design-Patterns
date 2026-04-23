namespace DecoratorPattern
{
    public interface IRequest
    {
        void Process();
    }

    public class BasicRequest : IRequest
    {
        public void Process()
        {
            Console.WriteLine("Processing Basic Request ...");
        }
    }

    public abstract class MiddlewareDecorator : IRequest
    {
        protected IRequest _request;

        protected MiddlewareDecorator(IRequest request)
        {
            _request = request;
        }

        public abstract void Process();
    }

    public class LoggingMiddleware : MiddlewareDecorator 
    {
        public LoggingMiddleware(IRequest request) : base(request) { }

        public override void Process()
        {
            Console.WriteLine("Logging Rewqeust");
            _request.Process();
        }
    }

    public class CachingMiddleware : MiddlewareDecorator
    {
        private static Dictionary<string, string> _cache = new();

        public CachingMiddleware(IRequest request) : base(request) { }

        public override void Process()
        {
            if(_cache.ContainsKey("key")) 
            {
                Console.WriteLine("Fetching from the cache");
                return;
            }

            _request.Process();
            _cache["key"] = "value";
        }
    }

    public class AuthenticationMiddleware : MiddlewareDecorator
    {
        public AuthenticationMiddleware(IRequest request) : base(request) { }

        public override void Process()
        {
            Console.WriteLine("Authenticating request");
            bool isAuthenticated = true;

            if (isAuthenticated)
                _request.Process();
            else
                Console.WriteLine("Authentication failed");
        }
    }
}
