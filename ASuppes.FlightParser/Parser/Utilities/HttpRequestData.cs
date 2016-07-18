using System.Collections.Generic;

namespace ASuppes.FlightParser.Parser.Utilities
{
    public class HttpRequestData
    {
        public HttpRequestData(string url, string contentType, params KeyValuePair<string, string>[] headers)
            : this(url, contentType, null, headers)
        {
        }

        public HttpRequestData(string url, string contentType, string requestData, params KeyValuePair<string, string>[] headers)
        {
            Url = url;
            ContentType = contentType;
            RequestData = requestData;
            Headers = new Dictionary<string, string>();
            SetHeaders(headers);
        }

        public string Url { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public string ContentType { get; set; }
        public string RequestData { get; set; }

        private void SetHeaders(KeyValuePair<string, string>[] headers)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    if (!string.IsNullOrEmpty(header.Key))
                    {
                        Headers[header.Key] = header.Value;
                    }
                }
            }
        }
    }
}