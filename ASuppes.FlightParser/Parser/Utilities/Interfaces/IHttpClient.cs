namespace ASuppes.FlightParser.Parser.Utilities
{
    public interface IHttpClient
    {
        HttpResponseData Get(HttpRequestData requestData);
        HttpResponseData Post(HttpRequestData requestData);
    }
}
