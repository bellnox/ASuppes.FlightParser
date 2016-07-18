namespace ASuppes.FlightParser.Parser.Utilities
{
    public interface IJsonParser
    {
        T DeserializeObject<T>(string data);
        string SerializeObject(object data);
    }
}
