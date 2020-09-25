using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SpedcordClient.api
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode statusCode, string response, bool hasResponse,
            Dictionary<string, string> responseHeaders)
        {
            StatusCode = statusCode;
            Response = response;
            HasResponse = hasResponse;
            ResponseHeaders = responseHeaders;
        }

        public HttpStatusCode StatusCode { get; }
        public string Response { get; set; }
        public bool HasResponse { get; }
        public Dictionary<string, string> ResponseHeaders { get; }

        public string ReadResponseMessage()
        {
            var reader = new JsonTextReader(new StringReader(Response));
            string msg = null;
            var next = false;
            while (reader.Read())
            {
                if (next)
                {
                    msg = (string) reader.Value;
                    break;
                }

                if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("message")) next = true;
            }

            return msg;
        }
    }
}