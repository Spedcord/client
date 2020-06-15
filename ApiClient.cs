using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace SpedcordClient
{
    public class ApiClient
    {
        private const string ApiServer = "https://api.spedcord.xyz";

        private RestClient _restClient;

        public ApiClient()
        {
            // Initialize RestClient
            _restClient = new RestClient(ApiServer)
            {
                UserAgent = "Spedcord/Client",
                Timeout = 3000,
                PreAuthenticate = true
            };
            _restClient.ConfigureWebRequest(rq => rq.KeepAlive = true);
        }

        public bool CheckAuth(long discordId, string key)
        {
            ApiResponse response = MakeApiRequest("/user/checkauth", "", new Dictionary<string, string>(),
                new Dictionary<string, string>()
                {
                    {"userDiscordId", "" + discordId},
                    {"key", key}
                }, "POST");
            return response.StatusCode == HttpStatusCode.OK;
        }

        public User GetUser(long discordId)
        {
            var response = MakeApiRequest("/user/info/" + discordId, "", new Dictionary<string, string>(),
                new Dictionary<string, string>(), "GET");

            var o = JsonConvert.DeserializeObject(response.Response, typeof(User));

            if (o == null)
            {
                return null;
            }

            return (User) o;
        }

        public Company GetCompany(int id)
        {
            var response = MakeApiRequest("/company/info?id=" + id, "", new Dictionary<string, string>(),
                new Dictionary<string, string>(), "GET");

            var o = JsonConvert.DeserializeObject(response.Response, typeof(Company));

            if (o == null)
            {
                return null;
            }

            return (Company) o;
        }

        public Job[] GetJobs(long discordId)
        {
            var response = MakeApiRequest("/user/jobs/" + discordId, "", new Dictionary<string, string>(),
                new Dictionary<string, string>(), "GET");

            var o = JsonConvert.DeserializeObject(response.Response, typeof(Job[]));

            if (o == null)
            {
                return null;
            }

            return (Job[]) o;
        }

        public ApiResponse StartJob(long discordId, String key, Job job)
        {
            var payload = new JsonObject
            {
                {"discordId", discordId},
                {"key", key},
                {"fromCity", job.FromCity},
                {"toCity", job.ToCity},
                {"truck", job.Truck},
                {"cargo", job.Cargo},
                {"cargoWeight", job.CargoWeight}
            };
            Debug.WriteLine(payload.ToString());

            return MakeApiRequest("/job/start", payload.ToString(), new Dictionary<string, string>(),
                new Dictionary<string, string>(), "POST");
        }

        public ApiResponse EndJob(long discordId, string key, double pay)
        {
            return MakeApiRequest("/job/end", "", new Dictionary<string, string>(),
                new Dictionary<string, string>()
                {
                    {"discordId", "" + discordId},
                    {"key", key},
                    {"pay", "" + pay}
                }, "POST");
        }

        public ApiResponse CancelJob(long discordId, string key)
        {
            return MakeApiRequest("/job/cancel", "", new Dictionary<string, string>(),
                new Dictionary<string, string>()
                {
                    {"discordId", "" + discordId},
                    {"key", key}
                }, "POST");
        }

        private ApiResponse MakeApiRequest(string path, string body, Dictionary<string, string> header,
            Dictionary<string, string> query, string method)
        {
            // Initialize RestRequest
            var restRequest = new RestRequest(path) {Method = Enum.TryParse(method, out Method tmp) ? tmp : Method.GET};

            // Add query parameters and headers to the request
            query.ForEach(pair => restRequest.AddQueryParameter(pair.Key, pair.Value));
            header.Where(pair => !pair.Key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase))
                .ForEach(pair => restRequest.AddHeader(pair.Key, pair.Value));

            // Write the body if the given string is not empty
            if (!body.Equals(""))
            {
                restRequest.Body = new RequestBody("text/plain", "text/plain", body);
            }

            // Execute the request and retrieve a response
            var restResponse = _restClient.Execute(restRequest);

            // Return the response in form of a parsed ApiResponse object
            return new ApiResponse(restResponse.StatusCode, restResponse.Content, !restResponse.Content.Equals(""),
                restResponse.Headers.Where(parameter => parameter.Type == ParameterType.HttpHeader)
                    .ToDictionary(parameter => parameter.Name, parameter => parameter.Value.ToString()));
        }
    }
}