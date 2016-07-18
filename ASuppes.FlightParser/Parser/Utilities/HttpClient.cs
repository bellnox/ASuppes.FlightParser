using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ASuppes.FlightParser.Parser.Utilities
{
    public class HttpClient : IHttpClient
    {
        private HttpResponseData BaseRequest(string method, HttpRequestData requestData)
        {
            try
            {
                WebRequest request = WebRequest.Create(requestData.Url);
                request.Method = method;
                if (requestData.Headers != null)
                {
                    foreach (KeyValuePair<string, string> headerPair in requestData.Headers)
                    {
                        request.Headers.Add(headerPair.Key, headerPair.Value);
                    }
                }
                request.ContentType = requestData.ContentType;
                if (!string.IsNullOrEmpty(requestData.RequestData))
                {
                    using (var stream = request.GetRequestStream())
                    using (var sw = new StreamWriter(stream))
                    {
                        sw.Write(requestData.RequestData);
                    }
                }

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return new HttpResponseData { Content = reader.ReadToEnd() };
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseData { Error = ex };
            }
        }

        public HttpResponseData Get(HttpRequestData requestData)
        {
            return BaseRequest("GET", requestData);
        }

        public HttpResponseData Post(HttpRequestData requestData)
        {
            return BaseRequest("POST", requestData);
        }
    }
}