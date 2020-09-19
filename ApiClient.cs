using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace SpedcordClient
{
    public class ApiClient
    {
        private const string ApiServer = "https://api.spedcord.xyz";
        private const string DevApiServer = "http://localhost:81";

        private readonly RestClient _restClient;

        public ApiClient()
        {
            // Initialize RestClient
            _restClient = new RestClient(Program.Dev ? DevApiServer : ApiServer)
            {
                UserAgent = "Spedcord/Client",
                Timeout = 3000,
                PreAuthenticate = true
            };
            _restClient.ConfigureWebRequest(rq => rq.KeepAlive = true);
        }

        public bool CheckAuth(long discordId, string key)
        {
            var response = MakeApiRequest("/user/checkauth", "", new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    {"userDiscordId", "" + discordId},
                    {"key", key}
                }, "POST");
            Debug.WriteLine(response.StatusCode);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public User GetUser(long discordId)
        {
            var response = MakeApiRequest("/user/info/" + discordId, "", new Dictionary<string, string>(),
                new Dictionary<string, string>(), "GET");

            var o = JsonConvert.DeserializeObject(response.Response, typeof(User));

            if (o == null) return null;

            return (User) o;
        }

        public Company GetCompany(int id)
        {
            var response = MakeApiRequest("/company/info?id=" + id, "", new Dictionary<string, string>(),
                new Dictionary<string, string>(), "GET");

            var o = JsonConvert.DeserializeObject(response.Response, typeof(Company));

            if (o == null) return null;

            return (Company) o;
        }

        public Job[] GetJobs(long discordId)
        {
            var response = MakeApiRequest("/user/jobs/" + discordId, "", new Dictionary<string, string>(),
                new Dictionary<string, string>(), "GET");

            var o = JsonConvert.DeserializeObject(response.Response, typeof(Job[]));

            if (o == null) return null;

            return (Job[]) o;
        }

        public ApiResponse UpdateMember(long user, string key, long company, long otherUser, string role)
        {
            return MakeApiRequest("/company/member/update", "", new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    {"companyDiscordId", company + ""},
                    {"changerDiscordId", user + ""},
                    {"userDiscordId", otherUser + ""},
                    {"role", role},
                    {"key", key}
                }, "POST");
        }

        public ApiResponse KickMember(long user, string key, long company, long otherUser)
        {
            return MakeApiRequest("/company/kickmember", "", new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    {"companyDiscordId", company + ""},
                    {"kickerDiscordId", user + ""},
                    {"userDiscordId", otherUser + ""},
                    {"key", key}
                }, "POST");
        }

        public ApiResponse CreateRole(long user, string key, int companyId, string roleName, double payout, int perms)
        {
            var payload = new JsonObject
            {
                {"memberDiscordIds", new JsonArray()},
                {"permissions", perms},
                {"name", roleName},
                {"payout", payout}
            };
            return MakeApiRequest("/company/role/update", payload.ToString(), new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    {"mode", "1"},
                    {"companyId", "" + companyId},
                    {"userDiscordId", "" + user},
                    {"key", key}
                }, "POST");
        }

        public ApiResponse RemoveRole(long user, string key, int companyId, string roleName)
        {
            var payload = new JsonObject
            {
                {"memberDiscordIds", new JsonArray()},
                {"permissions", 0},
                {"name", roleName},
                {"payout", 0}
            };
            return MakeApiRequest("/company/role/update", payload.ToString(), new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    {"mode", "2"},
                    {"companyId", "" + companyId},
                    {"userDiscordId", "" + user},
                    {"key", key}
                }, "POST");
        }

        public ApiResponse EditRole(long user, string key, int companyId, string roleName, double payout, int perms)
        {
            var payload = new JsonObject
            {
                {"memberDiscordIds", new JsonArray()},
                {"permissions", perms},
                {"name", roleName},
                {"payout", payout}
            };
            return MakeApiRequest("/company/role/update", payload.ToString(), new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    {"mode", "0"},
                    {"companyId", "" + companyId},
                    {"userDiscordId", "" + user},
                    {"key", key}
                }, "POST");
        }

        public ApiResponse StartJob(long discordId, string key, Job job)
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
                new Dictionary<string, string>
                {
                    {"discordId", "" + discordId},
                    {"key", key},
                    {"pay", "" + pay}
                }, "POST");
        }

        public ApiResponse CancelJob(long discordId, string key)
        {
            return MakeApiRequest("/job/cancel", "", new Dictionary<string, string>(),
                new Dictionary<string, string>
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
            if (!body.Equals("")) restRequest.Body = new RequestBody("text/plain", "text/plain", body);

            // Execute the request and retrieve a response
            var restResponse = _restClient.Execute(restRequest);

            // Return the response in form of a parsed ApiResponse object
            return new ApiResponse(restResponse.StatusCode, restResponse.Content, !restResponse.Content.Equals(""),
                restResponse.Headers.Where(parameter => parameter.Type == ParameterType.HttpHeader)
                    .ToDictionary(parameter => parameter.Name, parameter => parameter.Value.ToString()));
        }
    }
}