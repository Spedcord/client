using System.Collections.Generic;
using System.Net;

namespace SpedcordClient
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; }
        public string Response { get; }
        public bool HasResponse { get; }
        public Dictionary<string, string> ResponseHeaders { get; }
        
        public ApiResponse(HttpStatusCode statusCode, string response, bool hasResponse, Dictionary<string, string> responseHeaders)
        {
            StatusCode = statusCode;
            Response = response;
            HasResponse = hasResponse;
            ResponseHeaders = responseHeaders;
        }
    }
}