namespace AdapterPattern
{
    public interface IJsonWeatherProvider
    {
        string GetWeatherJson();
    }

    public class JsonWeatherService : IJsonWeatherProvider
    {
        public string GetWeatherJson()
        {
            return " { 'temperature': 22, 'condition': 'sunny'}";
        }
    }

    public class XmlWeatherService
    {
        public string GetWeatherXml()
        {
            return "<weather><temperature>22</temperature><condition>sunny</codition></weather>";
        }
    }

    public class XmlToJsonWeatherAdapter : IJsonWeatherProvider
    {
        private readonly XmlWeatherService _xmlWeatherService;
        public XmlToJsonWeatherAdapter(XmlWeatherService xmlWeatherService)
        {
            _xmlWeatherService = xmlWeatherService;
        }

        public string GetWeatherJson()
        {
            string xmlData = _xmlWeatherService.GetWeatherXml();

            // Convert to Json
            return " { 'temperature': 22, 'condition': 'sunny'}";
        }
    }
}
