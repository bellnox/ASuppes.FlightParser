using Newtonsoft.Json;

namespace ASuppes.FlightParser.Parser.Utilities
{
    public class JsonParserWrapper : IJsonParser
    {
        public T DeserializeObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string SerializeObject(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}